using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.CompilerServices;

public enum LogLevel
{
    Debug = 0,
    Info = 1,
    Warning = 2,
    Error = 3,
    None = 4
}

public class Logger
{
    /// <summary>
    /// 当前日志等级：只会输出等级 ≥ 当前等级 的日志
    /// </summary>
    public static LogLevel CurrentLevel = LogLevel.Debug;

    /// <summary>
    /// 是否在日志中包含函数名、文件名和行号
    /// </summary>
    public static bool IncludeCallerInfo = true;

    public static void DebugLog(string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        LogInternal(message, LogLevel.Debug, memberName, filePath, lineNumber);
    }

    public static void InfoLog(string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        LogInternal(message, LogLevel.Info, memberName, filePath, lineNumber);
    }

    public static void WarningLog(string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        LogInternal(message, LogLevel.Warning, memberName, filePath, lineNumber);
    }

    public static void ErrorLog(string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        LogInternal(message, LogLevel.Error, memberName, filePath, lineNumber);
    }

    private static void LogInternal(string message, LogLevel level,
        string memberName, string filePath, int lineNumber)
    {
        if (level < CurrentLevel || level == LogLevel.None)
            return;

        string prefix = $"[{level}]";

        if (IncludeCallerInfo)
        {
            string file = System.IO.Path.GetFileName(filePath);
            prefix += $" {file}:{lineNumber} ({memberName})";
        }

        string fullMessage = $"{prefix} {message}";

        switch (level)
        {
            case LogLevel.Debug:
            case LogLevel.Info:
                Debug.Log(fullMessage);
                break;
            case LogLevel.Warning:
                Debug.LogWarning(fullMessage);
                break;
            case LogLevel.Error:
                Debug.LogError(fullMessage);
                break;
        }
    }
}
