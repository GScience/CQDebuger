#pragma once

#include <cstdint>
#include <string>

#define CHECK_PERMISSION(auth) \
	if (!CQDebuger::CoolQ::CQPluginLoader::CheckAuthCodePermission(auth_code, auth)) \
	{ \
		std::string errorLog = "未能执行操作，缺少权限: " + std::to_string(auth); \
		CQP::addLog(auth_code, 1, "权限错误",errorLog.c_str()); \
		return -1; \
	} \
	""

public class CQP
{
	static System::String^ CStrToString(const char* c_str) 
	{
		auto ptr = static_cast<System::IntPtr>(const_cast<char*>(c_str));
		return System::Runtime::InteropServices::Marshal::PtrToStringAnsi(ptr);
	}

public:	
	using CQPBridge = CQDebuger::CoolQ::CQPBridge;
	
	static int32_t sendPrivateMsg(int32_t auth_code, int64_t qq, const char* msg)
	{
		CHECK_PERMISSION(106);
		return CQPBridge::sendPrivateMsg(auth_code, qq, CStrToString(msg));
	}

	static int32_t sendGroupMsg(int32_t auth_code, int64_t group_id, const char* msg)
	{
		CHECK_PERMISSION(101);
		return CQPBridge::sendGroupMsg(auth_code, group_id, CStrToString(msg));
	}

	static int32_t addLog(int32_t auth_code, int32_t log_level, const char* category, const char* log_msg)
	{
		return CQPBridge::addLog(auth_code, log_level, CStrToString(category), CStrToString(log_msg));
	}
};
