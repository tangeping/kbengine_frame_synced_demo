# -*- coding: utf-8 -*-
import KBEngine
import random
import time

from AVATAR_INFOS import TAvatarInfos
from AVATAR_INFOS import TAvatarInfosList
from AVATAR_DATA import TAvatarData
from KBEDebug import *


class Account(KBEngine.Proxy):
	"""
	账号实体
	客户端登陆到服务端后，服务端将自动创建这个实体，通过这个实体与客户端进行交互
	"""
	def __init__(self):
		KBEngine.Proxy.__init__(self)
		self.activeAvatar = None
		self.relogin = time.time()
	
	def reqAvatarList(self):
		"""
		exposed.
		客户端请求查询角色列表
		"""
		DEBUG_MSG("Account[%i].reqAvatarList: size=%i." % (self.id, len(self.characters)))
		#self.client.onReqAvatarList(self.characters)
				
	def reqCreateAvatar(self, roleType, name):
		"""
		exposed.
		客户端请求创建一个角色
		"""
		avatarinfo = TAvatarInfos()
		avatarinfo.extend([0, "", 0, 0, TAvatarData().createFromDict({"param1" : 0, "param2" :b''})])
			
		props = {
			"name"				: name,
			"roleType"			: roleType,
			"level"				: 1,
			"direction"			: (0, 0,0),
			"position"			: (0,0,0)
			}
			
		avatar = KBEngine.createEntityLocally('Avatar', props)
		if avatar:
			avatar.writeToDB(self._onAvatarSaved)
		
		DEBUG_MSG("Account[%i].reqCreateAvatar:%s.\n" % (self.id, name))
		
	def reqRemoveAvatar(self, name):
		"""
		exposed.
		客户端请求删除一个角色
		"""
		DEBUG_MSG("Account[%i].reqRemoveAvatar: %s" % (self.id, name))
		found = 0
		for key, info in self.characters.items():
			if info[1] == name:
				del self.characters[key]
				found = key
				break
		
		#self.client.onRemoveAvatar(found)
		
	def reqRemoveAvatarDBID(self, dbid):
		"""
		exposed.
		客户端请求删除一个角色
		"""
		DEBUG_MSG("Account[%i].reqRemoveAvatar: %s" % (self.id, dbid))
		found = 0
		
		if dbid in self.characters:
			del self.characters[dbid]
			found = dbid

		#self.client.onRemoveAvatar(found)

	def selectAvatarGame(self):
		"""
		exposed.
		客户端选择某个角色进行游戏
		"""
		DEBUG_MSG("Account[%i].selectAvatarGame:. self.activeAvatar=%s" % (self.id,  self.activeAvatar))
		# 注意:使用giveClientTo的entity必须是当前baseapp上的entity

		if self.activeAvatar is None:
			if len(self.characters) <= 0:
				ERROR_MSG("Account[%i]::selectAvatarGame: not found " % (self.id))
			else:
				for dbid in self.characters.keys():
					self.lastSelCharacter = dbid
					KBEngine.createEntityFromDBID("Avatar", dbid, self.__onAvatarCreated)
					break
		else:
			self.giveClientTo(self.activeAvatar)
		
	#--------------------------------------------------------------------------------------------
	#                              Callbacks
	#--------------------------------------------------------------------------------------------
	def onClientEnabled(self):
		"""
		KBEngine method.
		该entity被正式激活为可使用， 此时entity已经建立了client对应实体， 可以在此创建它的
		cell部分。
		"""
		INFO_MSG("Account[%i]::onClientEnabled:entities enable. entityCall:%s, clientType(%i), clientDatas=(%s), hasAvatar=%s, accountName=%s" % \
			(self.id, self.client, self.getClientType(), self.getClientDatas(), self.activeAvatar, self.__ACCOUNT_NAME__))

		if len(self.characters) <= 0:
			self.reqCreateAvatar(1,self.__ACCOUNT_NAME__)
		else:
			self.selectAvatarGame()

			
	def onLogOnAttempt(self, ip, port, password):
		"""
		KBEngine method.
		客户端登陆失败时会回调到这里
		"""
		INFO_MSG("Account[%i]::onLogOnAttempt: ip=%s, port=%i, selfclient=%s" % (self.id, ip, port, self.client))
		
		# 如果一个在线的账号被一个客户端登陆并且onLogOnAttempt返回允许
		# 那么会踢掉之前的客户端连接
		# 那么此时self.activeAvatar可能不为None， 常规的流程是销毁这个角色等新客户端上来重新选择角色进入
		if self.activeAvatar:
			if self.activeAvatar.client is not None:
				self.activeAvatar.giveClientTo(self)

			self.relogin = time.time()
			self.activeAvatar.destroySelf()
			self.activeAvatar = None
			
		return KBEngine.LOG_ON_ACCEPT
		
	def onClientDeath(self):
		"""
		KBEngine method.
		客户端对应实体已经销毁
		"""
		if self.activeAvatar:
			self.activeAvatar.accountEntity = None
			self.activeAvatar = None

		DEBUG_MSG("Account[%i].onClientDeath:" % self.id)
		self.destroy()		
		
	def onDestroy(self):
		"""
		KBEngine method.
		entity销毁
		"""
		DEBUG_MSG("Account::onDestroy: %i." % self.id)
		
		if self.activeAvatar:
			self.activeAvatar.accountEntity = None

			try:
				self.activeAvatar.destroySelf()
			except:
				pass
				
			self.activeAvatar = None
			
	def __onAvatarCreated(self, baseRef, dbid, wasActive):
		"""
		选择角色进入游戏时被调用
		"""
		if wasActive:
			ERROR_MSG("Account::__onAvatarCreated:(%i): this character is in world now!" % (self.id))
			return
		if baseRef is None:
			ERROR_MSG("Account::__onAvatarCreated:(%i): the character you wanted to created is not exist!" % (self.id))
			return
			
		avatar = KBEngine.entities.get(baseRef.id)
		if avatar is None:
			ERROR_MSG("Account::__onAvatarCreated:(%i): when character was created, it died as well!" % (self.id))
			return
		
		if self.isDestroyed:
			ERROR_MSG("Account::__onAvatarCreated:(%i): i dead, will the destroy of Avatar!" % (self.id))
			avatar.destroy()
			return
			
		info = self.characters[dbid]
		avatar.accountEntity = self
		self.activeAvatar = avatar
		self.giveClientTo(avatar)
		
	def _onAvatarSaved(self, success, avatar):
		"""
		新建角色写入数据库回调
		"""
		INFO_MSG('Account::_onAvatarSaved:(%i) create avatar state: %i, %s, %i' % (self.id, success, avatar.cellData["name"], avatar.databaseID))
		
		# 如果此时账号已经销毁， 角色已经无法被记录则我们清除这个角色
		if self.isDestroyed:
			if avatar:
				avatar.destroy(True)
				
			return
			
		avatarinfo = TAvatarInfos()
		avatarinfo.extend([0, "", 0, 0, TAvatarData().createFromDict({"param1" : 0, "param2" :b''})])

		if success:
			info = TAvatarInfos()
			info.extend([avatar.databaseID, avatar.cellData["name"], avatar.roleType, 1, TAvatarData().createFromDict({"param1" : 1, "param2" :b'1'})])
			self.characters[avatar.databaseID] = info
			avatarinfo[0] = avatar.databaseID
			avatarinfo[1] = avatar.cellData["name"]
			avatarinfo[2] = avatar.roleType
			avatarinfo[3] = 1
			self.writeToDB()
		else:
			avatarinfo[1] = "创建失败了"

		avatar.destroy()
		
		self.selectAvatarGame()
		#if self.client:
		#	self.client.onCreateAvatarResult(0, avatarinfo)
