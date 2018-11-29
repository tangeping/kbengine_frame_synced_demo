# -*- coding: utf-8 -*-
import KBEngine
from KBEDebug import * 


# 服务端timer定义
TIMER_TYPE_DESTROY									= 1 # 延时销毁entity
TIMER_TYPE_ROOM_DESTORY								= 2 # 房间销毁
TIMER_TYPE_ENTITY_DESTROY							= 3 # entity销毁

# 定义时间

#  一局时间（秒）
ROOM_ROUND_TIME = 3600 #60 * 60				