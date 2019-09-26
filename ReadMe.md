# CoolQ 调试器
## 可以干什么？
1. 更简单的进行调试
不需要使用真正的*CoolQ*， 不需要登陆自己的QQ号，可以自定义一切操作，并且所有操作均图形化，更易于操作

1. 兼容一切SDK开发的一切插件
与*CoolQ* API保持高度的一致性，只要你的插件在*CoolQ*当中正常，就可以用此调试器进行调试

1. 支持扩展
后期会支持插件，使用户可以自己编写单元测试、压力测试、仿真环境等等

## 食用方法
~~把代码打印出来备用，烧热油，待油温到达150°时，把代码丢入油锅，3分钟后倒入编译漆，小火慢炖5分钟出锅~~

打开解决方案，会看到`CQDebuger`和`CQP`两个项目，其中：

`CQP`与*CoolQ*官方提供的CQP相似，只不过把所有API调用转到了CQDebuger而不是*CoolQ*

`CQDebuger`是调试器的核心，他会自动加载插件，同时内置一个简单的图形界面来模拟事件、接收API调用，以及显示日志等。

我们直接编译CQP，编译时会自动先编译CQDebuger，编译完成后，把 **CQP.dll** 和 **CQDebuger.exe** 放到一起，然后运行CQDebuger，如果加载正常，将会在目录下新建`/dev`文件夹，然后具体的插件安装方式与*CoolQ*的开发模式下插件安装方式一致。

## 为什么叫CQDebuger而不是CQDebugger
我们Debug，当然时Bug越少越好，所以减少了一个g（别胡说明明就是你拼错了懒得改了）


注：此软件禁止用于任何商业目的上