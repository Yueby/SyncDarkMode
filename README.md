# SyncDarkMode

自动同步 Windows 系统主题到 Unity Editor 的深色/浅色主题工具。

## 功能特性

- 🔄 **自动同步**: 监听 Windows 系统主题变化，自动同步到 Unity Editor
- ⚙️ **可控制**: 通过编辑器窗口随时启用/禁用同步功能
- 🚀 **即时响应**: Windows 主题改变时立即同步 Unity Editor 主题
- 📦 **轻量级**: 仅包含必要的代码，无冗余依赖

## 安装

### 通过 Unity Package Manager

1. 打开 Unity Editor
2. 在 Package Manager 中点击 "+" 按钮
3. 选择 "Add package from git URL"
4. 输入 Git 仓库地址

### 手动安装

1. 克隆或下载仓库
2. 在 Package Manager 中点击 "Add package from disk"
3. 选择包文件夹

## 使用方法

### 启用同步

1. 在 Unity Editor 菜单栏选择 `Tools > YuebyTools > SyncDarkMode`
2. 在打开的窗口中点击开关，启用自动同步功能

### 工作原理

- 监听 Windows 注册表中的主题设置
- 当 Windows 主题改变时，自动调用 Unity 内部 API 切换 Editor 主题
- 使用 `InternalEditorUtility.SwitchSkinAndRepaintAllViews()` 实现主题切换

## 系统要求

- Unity 2022.3 或更高版本
- Windows 操作系统

## 许可证

MIT License
