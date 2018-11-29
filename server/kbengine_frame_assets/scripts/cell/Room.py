# -*- coding: utf-8 -*-
import KBEngine
from KBEDebug import *
import SCDefine

class Room(KBEngine.Entity):
	"""
	游戏场景
	"""
	def __init__(self):
		KBEngine.Entity.__init__(self)
		
		
		# 告诉客户端加载地图
		#KBEngine.addSpaceGeometryMapping(self.spaceID, None, "spaces/gameMap")
		
		DEBUG_MSG('created space[%d] entityID = %i, res = %s.' % (self.roomKeyC, self.id, "spaces/gameMap"))
		
		# 让baseapp和cellapp都能够方便的访问到这个房间的entityCall
		KBEngine.globalData["Room_%i" % self.spaceID] = self.base
	
		# 开始记录一局游戏时间， 时间结束后将玩家踢出空间同时销毁自己和空间
		self.addTimer(SCDefine.ROOM_ROUND_TIME, 0, SCDefine.TIMER_TYPE_ROOM_DESTORY)

		self.avatars = {}

	def reqReady(self,entityCall,ready):
		"""
		玩家开始准备
		"""
		if entityCall.component2.state !=  0:
			return

		entityCall.component2.state = 1

		readCount = 0
		for e in self.avatars.values():
			readCount = readCount + e.component2.state

		canBegin = (readCount == len(self.avatars))

		if not canBegin:
			return
		
		self.component1.start()

		for e in self.avatars.values():
			e.component2.client.readyResult(0)



		

	#--------------------------------------------------------------------------------------------
	#                              Callbacks
	#--------------------------------------------------------------------------------------------
	def onTimer(self, id, userArg):
		"""
		KBEngine method.
		使用addTimer后， 当时间到达则该接口被调用
		@param id		: addTimer 的返回值ID
		@param userArg	: addTimer 最后一个参数所给入的数据
		"""
		if SCDefine.TIMER_TYPE_ROOM_DESTORY == userArg:
			self.onDestroyTimer()

	def onDestroy(self):
		"""
		KBEngine method.
		"""
		DEBUG_MSG("Room::onDestroy: %i" % (self.id))
		del KBEngine.globalData["Room_%i" % self.spaceID]
		
	def onDestroyTimer(self):
		DEBUG_MSG("Room::onDestroyTimer: %i" % (self.id))
		# 请求销毁引擎中创建的真实空间，在空间销毁后，所有该空间上的实体都被销毁
		self.destroySpace()
	
		
	def onEnter(self, entityCall):
		"""
		defined method.
		进入场景
		"""		
		DEBUG_MSG('Room::onEnter space[%d] entityID = %i.' % (self.spaceID, entityCall.id))

		self.avatars[entityCall.id] = entityCall


	def onLeave(self, entityID):
		"""
		defined method.
		离开场景
		"""
		DEBUG_MSG('Room::onLeave space[%d] entityID = %i.' % (self.spaceID, entityID))

		if entityID in self.avatars:
			del self.avatars[entityID]


		


