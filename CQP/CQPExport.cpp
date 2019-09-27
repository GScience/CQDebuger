
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
	return CQP::sendDiscussMsg(auth_code, discuss_id, msg);
}
CQP_API_HELPER(int32_t, CQ_deleteMsg, 12) (int32_t auth_code, int64_t msg_id)
{
	return CQP::deleteMsg(auth_code, msg_id);
}

// Send Like
CQP_API_HELPER(int32_t, CQ_sendLike, 12) (int32_t auth_code, int64_t qq)
{
	return CQP::sendLike(auth_code, qq);
}
CQP_API_HELPER(int32_t, CQ_sendLikeV2, 16) (int32_t auth_code, int64_t qq, int32_t times)
{
	return CQP::sendLikeV2(auth_code, qq, times);
}

// Group & Discuss Operation
CQP_API_HELPER(int32_t, CQ_setGroupKick, 24) (int32_t auth_code, int64_t group_id, int64_t qq, cq_bool_t reject_add_request)
{
	return CQP::setGroupKick(auth_code, group_id, qq, reject_add_request);
}
CQP_API_HELPER(int32_t, CQ_setGroupBan, 28) (int32_t auth_code, int64_t group_id, int64_t qq, int64_t duration)
{
	return CQP::setGroupBan(auth_code, group_id, qq, duration);
}
CQP_API_HELPER(int32_t, CQ_setGroupAnonymousBan, 24) (int32_t auth_code, int64_t group_id, const char* anonymous, int64_t duration)
{
	return CQP::setGroupAnonymousBan(auth_code, group_id, anonymous, duration);
}
CQP_API_HELPER(int32_t, CQ_setGroupWholeBan, 16) (int32_t auth_code, int64_t group_id, cq_bool_t enable)
{
	return CQP::setGroupWholeBan(auth_code, group_id, enable);
}
CQP_API_HELPER(int32_t, CQ_setGroupAdmin, 24) (int32_t auth_code, int64_t group_id, int64_t qq, cq_bool_t set)
{
	return CQP::setGroupAdmin(auth_code, group_id, qq, set);
}
CQP_API_HELPER(int32_t, CQ_setGroupAnonymous, 16) (int32_t auth_code, int64_t group_id, cq_bool_t enable)
{
	return CQP::setGroupAnonymous(auth_code, group_id, enable);
}
CQP_API_HELPER(int32_t, CQ_setGroupCard, 24) (int32_t auth_code, int64_t group_id, int64_t qq, const char* new_card)
{
	return CQP::setGroupCard(auth_code, group_id, qq, new_card);
}
CQP_API_HELPER(int32_t, CQ_setGroupLeave, 16) (int32_t auth_code, int64_t group_id, cq_bool_t is_dismiss)
{
	return CQP::setGroupLeave(auth_code, group_id, is_dismiss);
}
CQP_API_HELPER(int32_t, CQ_setGroupSpecialTitle, 32) (int32_t auth_code, int64_t group_id, int64_t qq, const char* new_special_title, int64_t duration)
{
	return CQP::setGroupSpecialTitle(auth_code, group_id, qq, new_special_title, duration);
}
CQP_API_HELPER(int32_t, CQ_setDiscussLeave, 12) (int32_t auth_code, int64_t discuss_id)
{
	return CQP::setDiscussLeave(auth_code, discuss_id);
}

// Request Operation
CQP_API_HELPER(int32_t, CQ_setFriendAddRequest, 16) (int32_t auth_code, const char* response_flag, int32_t response_operation, const char* remark)
{
	return CQP::setFriendAddRequest(auth_code, response_flag, response_operation, remark);
}
CQP_API_HELPER(int32_t, CQ_setGroupAddRequest, 16) (int32_t auth_code, const char* response_flag, int32_t request_type, int32_t response_operation)
{
	return CQP::setGroupAddRequest(auth_code, response_flag, request_type, response_operation);
}
CQP_API_HELPER(int32_t, CQ_setGroupAddRequestV2, 20) (int32_t auth_code, const char* response_flag, int32_t request_type, int32_t response_operation, const char* reason)
{
	return CQP::setGroupAddRequestV2(auth_code, response_flag, request_type, response_operation, reason);
}

// Get QQ Information
CQP_API_HELPER(int32_t, CQ_getLoginQQ, 4) (int32_t auth_code)
{
	return CQP::getLoginQQ(auth_code);
}
CQP_API_HELPER(const char*, CQ_getLoginNick, 4) (int32_t auth_code)
{
	return CQP::getLoginNick(auth_code);
}
CQP_API_HELPER(const char*, CQ_getStrangerInfo, 16) (int32_t auth_code, int64_t qq, cq_bool_t no_cache)
{
	return CQP::getStrangerInfo(auth_code, qq, no_cache);
}
CQP_API_HELPER(const char*, CQ_getGroupList, 4) (int32_t auth_code)
{
	return CQP::getGroupList(auth_code);
}
CQP_API_HELPER(const char*, CQ_getGroupMemberList, 12) (int32_t auth_code, int64_t group_id)
{
	return CQP::getGroupMemberList(auth_code, group_id);
}
CQP_API_HELPER(const char*, CQ_getGroupMemberInfoV2, 24) (int32_t auth_code, int64_t group_id, int64_t qq, cq_bool_t no_cache)
{
	return CQP::getGroupMemberInfoV2(auth_code, group_id, qq, no_cache);
}

// Get CoolQ Information
CQP_API_HELPER(const char*, CQ_getCookies, 4) (int32_t auth_code)
{
	return CQP::getCookies(auth_code);
}
CQP_API_HELPER(int32_t, CQ_getCsrfToken, 4) (int32_t auth_code)
{
	return CQP::getCsrfToken(auth_code);
}
CQP_API_HELPER(const char*, CQ_getAppDirectory, 4) (int32_t auth_code)
{
	return CQP::getAppDirectory(auth_code);
}
CQP_API_HELPER(const char*, CQ_getRecord, 12) (int32_t auth_code, const char* file, const char* out_format)
{
	return CQP::getRecord(auth_code, file, out_format);
}
CQP_API_HELPER(const char*, CQ_getRecordV2, 12) (int32_t auth_code, const char* file, const char* out_format)
{
	return CQP::getRecordV2(auth_code, file, out_format);
}
CQP_API_HELPER(const char*, CQ_getImage, 8) (int32_t auth_code, const char* file)
{
	return CQP::getImage(auth_code, file);
}
CQP_API_HELPER(int32_t, CQ_canSendImage, 4) (int32_t auth_code)
{
	return CQP::canSendImage(auth_code);
}
CQP_API_HELPER(int32_t, CQ_canSendRecord, 4) (int32_t auth_code)
{
	return CQP::canSendRecord(auth_code);
}


CQP_API_HELPER(int32_t, CQ_addLog, 16) (int32_t auth_code, int32_t log_level, const char* category, const char* log_msg)
{
	return CQP::addLog(auth_code, log_level, category, log_msg);
}
CQP_API_HELPER(int32_t, CQ_setFatal, 8) (int32_t auth_code, const char* error_info)
{
	return CQP::setFatal(auth_code, error_info);
}
CQP_API_HELPER(int32_t, CQ_setRestart, 4) (int32_t auth_code)
{
	return CQP::setRestart(auth_code);
}