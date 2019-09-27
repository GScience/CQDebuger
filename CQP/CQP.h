#pragma once

#include <cstdint>
#include <string>

#define CHECK_PERMISSION(auth) \
	if (!CQDebuger::CoolQ::CQPluginLoader::CheckAuthCodePermission(authCode, auth)) \
	{ \
		std::string errorLog = "未能执行操作，缺少权限: " + std::to_string(auth); \
		CQP::addLog(authCode, 1, "权限错误",errorLog.c_str()); \
		return 0; \
	} \
	""

public class CQP
{
	static System::String^ CStrToString(const char* c_str)
	{
		auto ptr = static_cast<System::IntPtr>(const_cast<char*>(c_str));
		return System::Runtime::InteropServices::Marshal::PtrToStringAnsi(ptr);
	}
	static const char* StringToCStr(System::String^ str)
	{
		return reinterpret_cast<char*>(System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(str).ToPointer());
	}

public:	
	using CQPBridge = CQDebuger::CoolQ::CQPBridge;

	static int32_t sendPrivateMsg(int32_t authCode, int64_t qq, const char* msg);
	static int32_t sendGroupMsg(int32_t authCode, int64_t groupId, const char* msg);
	static int32_t addLog(int32_t authCode, int32_t logLevel, const char* category, const char* logMsg);
	static int32_t sendDiscussMsg(int32_t authCode, int64_t discussId, const char* msg);
	static int32_t deleteMsg(int32_t authCode, int64_t msgId);
	static int32_t sendLike(int32_t authCode, int64_t qq);
	static int32_t sendLikeV2(int32_t authCode, int64_t qq, int32_t times);
	static int32_t setGroupKick(int32_t authCode, int64_t groupId, int64_t qq, int32_t rejectAddRequest);
	static int32_t setGroupBan(int32_t authCode, int64_t groupId, int64_t qq, int64_t duration);
	static int32_t setGroupAnonymousBan(int32_t authCode, int64_t groupId, const char* anonymous, int64_t duration);
	static int32_t setGroupWholeBan(int32_t authCode, int64_t groupId, int32_t enable);
	static int32_t setGroupAdmin(int32_t authCode, int64_t groupId, int64_t qq, int32_t set);
	static int32_t setGroupAnonymous(int32_t authCode, int64_t groupId, int32_t enable);
	static int32_t setGroupCard(int32_t authCode, int64_t groupId, int64_t qq, const char* newCard);
	static int32_t setGroupLeave(int32_t authCode, int64_t groupId, int32_t isDismiss);
	static int32_t setGroupSpecialTitle(int32_t authCode, int64_t groupId, int64_t qq, const char* newSpecialTitle, int64_t duration);
	static int32_t setDiscussLeave(int32_t authCode, int64_t discussId);
	static int32_t setFriendAddRequest(int32_t authCode, const char* responseFlag, int32_t responseOperation, const char* remark);
	static int32_t setGroupAddRequest(int32_t authCode, const char* responseFlag, int32_t requestType, int32_t responseOperation);
	static int32_t setGroupAddRequestV2(int32_t authCode, const char* responseFlag, int32_t requestType, int32_t responseOperation, const char* reason);
	static int32_t getLoginQQ(int32_t authCode);
	static const char* getLoginNick(int32_t authCode);
	static const char* getStrangerInfo(int32_t authCode, int64_t qq, int32_t noCache);
	static const char* getGroupList(int32_t authCode);
	static const char* getGroupMemberList(int32_t authCode, int64_t groupId);
	static const char* getGroupMemberInfoV2(int32_t authCode, int64_t groupId, int64_t qq, int32_t noCache);
	static const char* getCookies(int32_t authCode);
	static int32_t getCsrfToken(int32_t authCode);
	static const char* getAppDirectory(int32_t authCode);
	static const char* getRecord(int32_t authCode, const char* file, const char* outFormat);
	static const char* getRecordV2(int32_t authCode, const char* file, const char* outFormat);
	static const char* getImage(int32_t authCode, const char* file);
	static int32_t canSendImage(int32_t authCode);
	static int32_t canSendRecord(int32_t authCode);
	static int32_t setFatal(int32_t authCode, const char* errorInfo);
	static int32_t setRestart(int32_t authCode);
};
