# -*- coding: utf-8 -*-
import KBEngine
from KBEDebug import *


class Operation(KBEngine.EntityComponent):
	def __init__(self):
		KBEngine.EntityComponent.__init__(self)
	

	def onAttached(self, owner):
		"""
		"""			
		INFO_MSG("Operation::onAttached(): owner=%i" % (owner.id))


	def onDetached(self, owner):
		"""
		"""
		INFO_MSG("Operation::onDetached(): owner=%i" % (owner.id))


	def reqReady(self, exposed,ready):
		"""
		exposed.
		客户端请求删除一个角色
		"""
		if exposed != self.owner.id:
			return

		room = self.owner.getCurrRoom()
		if room:
			room.reqReady(self.owner,ready)

		#DEBUG_MSG("Operation[%i].reqReady:%d ." % (self.owner.id,ready))








