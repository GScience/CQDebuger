
#include <cstdint>
#include "CQP.h"

#define CQP_API_HELPER(ReturnType, Name, Size) \
	__pragma(comment(linker, "/EXPORT:" #Name "=_" #Name "@" #Size)) extern "C" __declspec(dllexport) \
	ReturnType __stdcall Name

using cq_bool_t = int32_t;

// Message
CQP_API_HELPER(int32_t, CQ_sendPrivateMsg, 16) (int32_t auth_code, int64_t qq, const char* msg)
{
	return CQP::sendPrivateMsg(auth_code, qq, msg);
}

CQP_API_HELPER(int32_t,CQ_sendGroupMsg, 16) (int32_t auth_code, int64_t group_id, const char* msg)
{
	return CQP::sendGroupMsg(auth_code, group_id, msg);
}
CQP_API_HELPER(int32_t, CQ_sendDiscussMsg, 16) (int32_t auth_code, int64_t discuss_id, const char* msg)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_deleteMsg, 12) (int32_t auth_code, int64_t msg_id)
{
	return 0;
}

// Send Like
CQP_API_HELPER(int32_t, CQ_sendLike, 12) (int32_t auth_code, int64_t qq)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_sendLikeV2, 16) (int32_t auth_code, int64_t qq, int32_t times)
{
	return 0;
}

// Group & Discuss Operation
CQP_API_HELPER(int32_t, CQ_setGroupKick, 24) (int32_t auth_code, int64_t group_id, int64_t qq, cq_bool_t reject_add_request)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_setGroupBan, 28) (int32_t auth_code, int64_t group_id, int64_t qq, int64_t duration)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_setGroupAnonymousBan, 24) (int32_t auth_code, int64_t group_id, const char* anonymous, int64_t duration)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_setGroupWholeBan, 16) (int32_t auth_code, int64_t group_id, cq_bool_t enable)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_setGroupAdmin, 24) (int32_t auth_code, int64_t group_id, int64_t qq, cq_bool_t set)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_setGroupAnonymous, 16) (int32_t auth_code, int64_t group_id, cq_bool_t enable)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_setGroupCard, 24) (int32_t auth_code, int64_t group_id, int64_t qq, const char* new_card)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_setGroupLeave, 16) (int32_t auth_code, int64_t group_id, cq_bool_t is_dismiss)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_setGroupSpecialTitle, 32) (int32_t auth_code, int64_t group_id, int64_t qq, const char* new_special_title, int64_t duration)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_setDiscussLeave, 12) (int32_t auth_code, int64_t discuss_id)
{
	return 0;
}

// Request Operation
CQP_API_HELPER(int32_t, CQ_setFriendAddRequest, 16) (int32_t auth_code, const char* response_flag, int32_t response_operation, const char* remark)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_setGroupAddRequest, 16) (int32_t auth_code, const char* response_flag, int32_t request_type, int32_t response_operation)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_setGroupAddRequestV2, 20) (int32_t auth_code, const char* response_flag, int32_t request_type, int32_t response_operation, const char* reason)
{
	return 0;
}

// Get QQ Information
CQP_API_HELPER(int32_t, CQ_getLoginQQ, 4) (int32_t auth_code)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_getLoginNick, 4) (int32_t auth_code)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_getStrangerInfo, 16) (int32_t auth_code, int64_t qq, cq_bool_t no_cache)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_getGroupList, 4) (int32_t auth_code)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_getGroupMemberList, 12) (int32_t auth_code, int64_t group_id)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_getGroupMemberInfoV2, 24) (int32_t auth_code, int64_t group_id, int64_t qq, cq_bool_t no_cache)
{
	return 0;
}

// Get CoolQ Information
CQP_API_HELPER(int32_t, CQ_getCookies, 4) (int32_t auth_code)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_getCsrfToken, 4) (int32_t auth_code)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_getAppDirectory, 4) (int32_t auth_code)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_getRecord, 12) (int32_t auth_code, const char* file, const char* out_format)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_getRecordV2, 12) (int32_t auth_code, const char* file, const char* out_format)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_getImage, 8) (int32_t auth_code, const char* file)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_canSendImage, 4) (int32_t auth_code)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_canSendRecord, 4) (int32_t auth_code)
{
	return 0;
}


CQP_API_HELPER(int32_t, CQ_addLog, 16) (int32_t auth_code, int32_t log_level, const char* category, const char* log_msg)
{
	return CQP::addLog(auth_code, log_level, category, log_msg);
}
CQP_API_HELPER(int32_t, CQ_setFatal, 8) (int32_t auth_code, const char* error_info)
{
	return 0;
}
CQP_API_HELPER(int32_t, CQ_setRestart, 4) (int32_t auth_code)
{
	return 0;
}