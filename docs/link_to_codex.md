
## 🔵 说明

基于 [replace-mcp-server-unity-cli](https://docs.unity.com/en-us/unity-cli/replace-mcp-server-unity-cli)。

Unity 已弃用编辑器 AI 助手包中包含的 MCP 服务器。Unity CLI 取代了该 MCP 服务器，后续不再使用 MCP。

### 🔷 Unity CLI

运行在终端里的命令行工具。负责让人或 AI 从 Unity 外部执行命令，例如查看项目状态、触发编译、执行 Editor 操作。

### 🔷 Unity Pipeline

安装在 Unity 项目里的 Package。负责把 Unity CLI 的请求真正接入正在运行的 Unity Editor。

```text
Codex / PowerShell
        ↓
    Unity CLI
        ↓
 Unity Pipeline
        ↓
  Unity Editor
```

## 🔵 使用 Unity CLI + Unity Pipeline

### 🔷 确认 Unity CLI

如果你的 Unity Hub 比较新，Unity Hub 已经会自动安装 Unity CLI。先打开 PowerShell：

```bash
unity --version

```

能看到类似：

```bash
1.0.0-beta.11
```

### 🔷 登录 Unity CLI

执行：

```bash
unity auth login
```

它会打开浏览器进行 Unity 账号登录。

然后检查：

```bash
unity auth status
```

### 🔷 给项目安装 Unity Pipeline

打开 Unity Editor，在项目根目录执行：

```bash
unity pipeline install
```

### 🔷 检查 Pipeline 是否连上

执行：

```bash
unity pipeline list
```

