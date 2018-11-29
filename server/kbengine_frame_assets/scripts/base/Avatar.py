# -*- coding: utf-8 -*-
import KBEngine
from KBEDebug import *
import GlobalDefine
import SCDefine
import random


class Avatar(KBEngine.Proxy):
	def __init__(self):
		KBEngine.Proxy.__init__(self)

		self.cellData["dbid"] = self.databaseID


		self._destroyTimer = 0
		
	def createCell(self, space, roomKey):
		"""
		defined method.
		创建cell实体
		"""
		self.roomKey = roomKey
		self.createCellEntity(space)
	
	def destroySelf(self):
		"""
		"""
		if self.client is not None:
			return
		
		# 必须先销毁cell实体，才能销毁base
		if self.cell is not None:
			self.destroyCellEntity()
			return

		KBEngine.globalData["Halls"].leaveRoom(self.id, self.roomKey)

		# 销毁base
		self.destroy()
		self._destroyTimer = 0

	def onTimer(self, id, userArg):
		"""
		KBEngine method.
		使用addTimer后， 当时间到达则该接口被调用
		@param id		: addTimer 的返回值ID
		@param userArg	: addTimer 最后一个参数所给入的数据
		"""
		if SCDefine.TIMER_TYPE_DESTROY == userArg:
			self.onDestroyTimer()
			
	def onClientEnabled(self):
		"""
		KBEngine method.
		该entity被正式激活为可使用， 此时entity已经建立了client对应实体， 可以在此创建它的
		cell部分。
		"""
		INFO_MSG("Avatar[%i] entities enable. EntityCall:%s" % (self.id, self.client))
		
		# 如果销毁玩家计时器已经开启了，此处玩家又上线了那么应该取消计时器
		if self._destroyTimer > 0:
			self.delTimer(self._destroyTimer)
			self._destroyTimer = 0
			
		# 如果玩家存在cell， 说明已经在地图中了， 因此不需要再次进入地图
		if self.cell is None:
			# 玩家上线了或者重登陆了， 此处告诉大厅，玩家请求登陆到游戏地图中
			KBEngine.globalData["Halls"].enterRoom(self, self.cellData["position"], self.cellData["direction"], self.roomKey)
				
	def onGetCell(self):
		"""
		KBEngine method.
		entity的cell部分实体被创建成功
		"""
		DEBUG_MSG('Avatar::onGetCell: %s' % self.cell)

	def onLoseCell(self):
		"""
		KBEngine method.
		entity的cell部分实体丢失
		"""
		DEBUG_MSG("%s::onLoseCell: %i" % (self.className, self.id))
		
		# 如果self._destroyTimer大于0说明之前已经由base请求销毁，通常是客户端断线了
		if self._destroyTimer > 0:
			self.destroySelf()
			
		# 否则由cell发起销毁， 那么说明游戏结束了

	def onRestore(self):
		"""
		KBEngine method.
		entity的cell部分实体被恢复成功
		"""
		DEBUG_MSG("%s::onRestore: %s" % (self.getScriptName(), self.cell))
		
	def onClientDeath(self):
		"""
		KBEngine method.
		客户端对应实体已经销毁
		"""
		DEBUG_MSG("Avatar[%i].onClientDeath:" % self.id)

		
	def onDestroyTimer(self):
		DEBUG_MSG("Avatar::onDestroyTimer: %i" % (self.id))
		self.destroySelf()
		
