# LiQing

## 介绍
基于ET框架的盲僧模拟器，包含完整的客户端与服务端交互，热更新，寻路，技能施放



## 运行环境

 **编辑器：Unity 2019.3** 

 **客户端：.Net Framework 4.7.2** 

 **服务端：.Net Core 2.2** 
 **MongoDB** 
## 运行步骤  
##### 1.visual studio必须使用vs2017 以上（更新到最新版）, VS2017需要勾选安装以下内容:
a. .net 桌面开发  
b. visual studio tools for unity  
c. 去net core 官网下载安装 .net core 2.1  

##### 2. 启动unity， 菜单 File->open project->open 选中ET/Unity文件夹，点击选择文件夹按钮。

##### 3.点击Unity菜单Assets->open C# project启动vs 编译（一定要编译，右键VS解决方案，全部编译）

##### 4.用vs2017打开ET/Server/Server.sln 编译（一定要编译，右键VS解决方案，全部编译）

##### 5.打开Unity->tools菜单->命令行配置，选择LocalAllServer.txt 这是启动单一App的方式，如果要启动一组多App服务器，在命令行工具中选择127.0.0.1.txt,点击启动即可，具体配置都可以自己用这个命令行配置工具修改  
##### 6.点击工具中的启动，这样就启动了服务端（也可以用VS启动，方便单步调试）  
##### 7.运行Unity，输入帐号、密码 ，点击登录  
## 已实现功能

- 整合FairyGUI 
- 资源的下载更新界面和逻辑开发完成 
- 登录注册，接入MongoDB数据库 
- 人物同步，自动寻路
- 整合Box2D作为服务端碰撞方案  
- 技能施放效果
## 待实现

1. 战斗伤害
2. 技能ui状态



