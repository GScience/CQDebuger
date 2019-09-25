#pragma once

#include <cstdint>

public class CQP
{
	static System::String^ CStrToString(const char* c_str) 
	{
		auto ptr = static_cast<System::IntPtr>(const_cast<char*>(c_str));
		return System::Runtime::InteropServices::Marshal::PtrToStringAnsi(ptr);
	}

public:
	using CQBridge = CQDebuger::CoolQ::CQPBridge;

	static int32_t sendPrivateMsg(int32_t auth_code, int64_t qq, const char* msg)
	{
		return CQBridge::sendPrivateMsg(auth_code, qq, CStrToString(msg));
	}

	static int32_t sendGroupMsg(int32_t auth_code, int64_t group_id, const char* msg)
	{
		return CQBridge::sendGroupMsg(auth_code, group_id, CStrToString(msg));
	}

	static int32_t addLog(int32_t auth_code, int32_t log_level, const char* category, const char* log_msg)
	{
		return CQBridge::addLog(auth_code, log_level, CStrToString(category), CStrToString(log_msg));
	}
};
