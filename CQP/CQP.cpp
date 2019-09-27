#include "CQP.h"

int32_t CQP::addLog(int32_t authCode, int32_t logLevel, const char* category, const char* logMsg)
{
	CHECK_PERMISSION(-1);
	return CQPBridge::addLog(
		authCode,
		static_cast<CQDebuger::CoolQ::CQLogLevel>(logLevel),
		CStrToString(category),
		CStrToString(logMsg));
}

int32_t CQP::sendPrivateMsg(int32_t authCode, int64_t qq, const char* msg)
{
	CHECK_PERMISSION(106);
	return CQPBridge::sendPrivateMsg(authCode, qq, CStrToString(msg));
}

int32_t CQP::sendGroupMsg(int32_t authCode, int64_t groupId, const char* msg)
{
	CHECK_PERMISSION(101);
	return CQPBridge::sendGroupMsg(authCode, groupId, CStrToString(msg));
}

int32_t CQP::sendDiscussMsg(int32_t authCode, int64_t discussId, const char* msg)
{
	CHECK_PERMISSION(103);
	return CQPBridge::sendDiscussMsg(authCode, discussId, CStrToString(msg));
}

int32_t CQP::deleteMsg(int32_t authCode, int64_t msgId)
{
	CHECK_PERMISSION(180);
	return CQPBridge::deleteMsg(authCode, msgId);
}

int32_t CQP::sendLike(int32_t authCode, int64_t qq)
{
	CHECK_PERMISSION(110);
	return CQPBridge::sendLike(authCode, qq);
}

int32_t CQP::sendLikeV2(int32_t authCode, int64_t qq, int32_t times)
{
	CHECK_PERMISSION(110);
	return CQPBridge::sendLikeV2(authCode, qq, times);
}

int32_t CQP::setGroupKick(int32_t authCode, int64_t groupId, int64_t qq, int32_t rejectAddRequest)
{
	CHECK_PERMISSION(120);
	return CQPBridge::setGroupKick(authCode, groupId, qq, rejectAddRequest);
}

int32_t CQP::setGroupBan(int32_t authCode, int64_t groupId, int64_t qq, int64_t duration)
{
	CHECK_PERMISSION(121);
	return CQPBridge::setGroupBan(authCode, groupId, qq, duration);
}

int32_t CQP::setGroupAnonymousBan(int32_t authCode, int64_t groupId, const char* anonymous, int64_t duration)
{
	CHECK_PERMISSION(124);
	return CQPBridge::setGroupAnonymousBan(authCode, groupId, CStrToString(anonymous), duration);
}

int32_t CQP::setGroupWholeBan(int32_t authCode, int64_t groupId, int32_t enable)
{
	CHECK_PERMISSION(123);
	return CQPBridge::setGroupWholeBan(authCode, groupId, enable);
}

int32_t CQP::setGroupAdmin(int32_t authCode, int64_t groupId, int64_t qq, int32_t set)
{
	CHECK_PERMISSION(122);
	return CQPBridge::setGroupAdmin(authCode, groupId, qq, set);
}

int32_t CQP::setGroupAnonymous(int32_t authCode, int64_t groupId, int32_t enable)
{
	CHECK_PERMISSION(125);
	return CQPBridge::setGroupAnonymous(authCode, groupId, enable);
}

int32_t CQP::setGroupCard(int32_t authCode, int64_t groupId, int64_t qq, const char* newCard)
{
	CHECK_PERMISSION(126);
	return CQPBridge::setGroupCard(authCode, groupId, qq, CStrToString(newCard));
}

int32_t CQP::setGroupLeave(int32_t authCode, int64_t groupId, int32_t isDismiss)
{
	CHECK_PERMISSION(127);
	return CQPBridge::setGroupLeave(authCode, groupId, isDismiss);
}

int32_t CQP::setGroupSpecialTitle(int32_t authCode, int64_t groupId, int64_t qq, const char* newSpecialTitle,
	int64_t duration)
{
	CHECK_PERMISSION(128);
	return CQPBridge::setGroupSpecialTitle(authCode, groupId, qq, CStrToString(newSpecialTitle), duration);
}

int32_t CQP::setDiscussLeave(int32_t authCode, int64_t discussId)
{
	CHECK_PERMISSION(140);
	return CQPBridge::setDiscussLeave(authCode, discussId);
}

int32_t CQP::setFriendAddRequest(int32_t authCode, const char* responseFlag, int32_t responseOperation,
	const char* remark)
{
	CHECK_PERMISSION(150);
	return CQPBridge::setFriendAddRequest(authCode, CStrToString(responseFlag), responseOperation, CStrToString(remark));
}

int32_t CQP::setGroupAddRequest(int32_t authCode, const char* responseFlag, int32_t requestType,
	int32_t responseOperation)
{
	CHECK_PERMISSION(151);
	return CQPBridge::setGroupAddRequest(authCode, CStrToString(responseFlag), requestType, responseOperation);
}

int32_t CQP::setGroupAddRequestV2(int32_t authCode, const char* responseFlag, int32_t requestType,
	int32_t responseOperation, const char* reason)
{
	CHECK_PERMISSION(151);
	return CQPBridge::setGroupAddRequestV2(authCode, CStrToString(responseFlag), requestType, responseOperation, CStrToString(reason));
}

int32_t CQP::getLoginQQ(int32_t authCode)
{
	CHECK_PERMISSION(-1);
	return CQPBridge::getLoginQQ(authCode);
}

const char* CQP::getLoginNick(int32_t authCode)
{
	CHECK_PERMISSION(-1);
	return StringToCStr(CQPBridge::getLoginNick(authCode));
}

const char* CQP::getStrangerInfo(int32_t authCode, int64_t qq, int32_t noCache)
{
	CHECK_PERMISSION(131);
	return StringToCStr(CQPBridge::getStrangerInfo(authCode, qq, noCache));
}

const char* CQP::getGroupList(int32_t authCode)
{
	CHECK_PERMISSION(161);
	return StringToCStr(CQPBridge::getGroupList(authCode));
}

const char* CQP::getGroupMemberList(int32_t authCode, int64_t groupId)
{
	CHECK_PERMISSION(160);
	return StringToCStr(CQPBridge::getGroupMemberList(authCode, groupId));
}

const char* CQP::getGroupMemberInfoV2(int32_t authCode, int64_t groupId, int64_t qq, int32_t noCache)
{
	CHECK_PERMISSION(130);
	return StringToCStr(CQPBridge::getGroupMemberInfoV2(authCode, groupId, qq, noCache));
}

const char* CQP::getCookies(int32_t authCode)
{
	CHECK_PERMISSION(20);
	return StringToCStr(CQPBridge::getCookies(authCode));
}

int32_t CQP::getCsrfToken(int32_t authCode)
{
	CHECK_PERMISSION(20);
	return CQPBridge::getCsrToken(authCode);
}

const char* CQP::getAppDirectory(int32_t authCode)
{
	CHECK_PERMISSION(-1);
	return StringToCStr(CQPBridge::getAppDirectory(authCode));
}

const char* CQP::getRecord(int32_t authCode, const char* file, const char* outFormat)
{
	CHECK_PERMISSION(30);
	return StringToCStr(CQPBridge::getRecord(authCode, CStrToString(file), CStrToString(outFormat)));
}

const char* CQP::getRecordV2(int32_t authCode, const char* file, const char* outFormat)
{
	CHECK_PERMISSION(30);
	return StringToCStr(CQPBridge::getRecordV2(authCode, CStrToString(file), CStrToString(outFormat)));
}

const char* CQP::getImage(int32_t authCode, const char* file)
{
	CHECK_PERMISSION(-1);
	return StringToCStr(CQPBridge::getImage(authCode, CStrToString(file)));
}

int32_t CQP::canSendImage(int32_t authCode)
{
	CHECK_PERMISSION(-1);
	return CQPBridge::canSendImage(authCode);
}

int32_t CQP::canSendRecord(int32_t authCode)
{
	CHECK_PERMISSION(-1);
	return CQPBridge::canSendRecord(authCode);
}

int32_t CQP::setFatal(int32_t authCode, const char* errorInfo)
{
	CHECK_PERMISSION(-1);
	return CQPBridge::setFatal(authCode, CStrToString(errorInfo));
}

int32_t CQP::setRestart(int32_t authCode)
{
	CHECK_PERMISSION(-1);
	return CQPBridge::setRestart(authCode);
}