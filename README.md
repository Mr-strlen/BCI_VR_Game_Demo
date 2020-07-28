# BCI_VR_Game_Demo
这是我们从2017.9-2019.5，在本科阶段完成的国家大学生创新创业项目  
《基于视觉刺激和运动想象的脑机接口-虚拟现实动态密室逃脱游戏研发》  
  
选择这样一个课题主要是从以下两个方面考虑：  
* 对于BCI交互而言，我们认为主动式的BCI这种需要外部刺激诱发的交互方式不够自然，被动式的BCI又一直缺少典型的交互场景。何为典型应用场景，简而言之，就是别的交互方式所不能取代的，这点我们在下面展开。
  
* 对于VR而言，我们虽然现在有手柄，但是手柄实现的还是键盘鼠标的移动点击菜单模式。相比之下，语音和手势识别，并不能被别的交互方式所取代，那这就算是种完全新的交互模式。与之类似的，BCI也有其独特性的一面，特别是对“个人状态”“情绪”的衡量上。  
我们可以回想一下各种游戏中对“魔法”“精神力”这类操作的定义模式，比如一个咏唱的进度条，或者长按某个键蓄能，那如果我们可以直接检测用户自己的注意力集中程度，那这个交互方式就能够更让人沉浸，也显得更加自然。  
这就是这个BCI-VR项目后续项目的出发点，也就是我的毕设了，目前还在进行中，之后等项目完成了，也会在github上公开。
  
* ~~还有我的个人情怀，总觉得脑机接口是人类发展必经之路，希望能够推动人类进步那么一点点，但是目前看来这个想法破灭了。~~
  
稍微有点遗憾的事情是，因为这个项目进行过程中一波三折，所以最后实现的是基础的SSVEP控制移动和场景切换，预期中运动想象控制和注意力检测的部分没有完成。  


## 文件结构
由于源文件是一口气上传上来了，没有具体的内容说明，所以这里简单介绍一下各个部分：  
`Export_Program` 导出的Unity程序  
`Matlab_Code` 数据处理代码，主要是脑电的收取，预处理，切割，和CCA结果输出  
`NovWork` Unity源程序（不要问为什么叫这个，问就是有故事）  


## 项目介绍
我们使用的是八导盐水电极脑电帽，利用nural平台采集设备数据，利用通讯接口传输到matlab中进行数据切片和预处理；之后利用CCA算法，输出识别的分类，将结果输入到Unity项目中，从而实现场景切换和人物移动控制。
![image](https://github.com/Mr-strlen/BCI_VR_Game_Demo/blob/master/Images/eeg_equipment.jpg)  
项目结构：
![image](https://github.com/Mr-strlen/BCI_VR_Game_Demo/blob/master/Images/total_model.png)
项目流程：
![image](https://github.com/Mr-strlen/BCI_VR_Game_Demo/blob/master/Images/total_process.png)


## 场景展示
我们也是给场景编了个故事：  
一名带着压缩食品的旅行者在2100年的荒漠中旅行，在一处古建筑遗迹发现了一个神秘的发光木箱。这个时代的人已经可以通过激光眼镜来意念操作物品。  
  
![image](https://github.com/Mr-strlen/BCI_VR_Game_Demo/blob/master/Images/sence1_01.jpg)  
  
他抬起木箱，发现了一样从未见过的东西：奄奄一息的植物的幼苗。幼苗被栽种在沟渠的槽里，大概是什么时候遗留下来的保护设施。  
有水就会有生命……他环顾四周，看见一只生锈的大铁桶。随着箱子被抬起，似乎有什么机关被触发了，桶开始闪烁不停。  
  
![image](https://github.com/Mr-strlen/BCI_VR_Game_Demo/blob/master/Images/sence1_02.jpg)  
  
似乎感受到旅人的注意，桶盖自动滑到一边流出清水。  
清水浇灌幼苗，它以惊人的速度长大了。  
  
![image](https://github.com/Mr-strlen/BCI_VR_Game_Demo/blob/master/Images/sence1_03.jpg)  
  
树上结出奇妙的果实。  
旅人久久凝视着，将两颗果实一一击落，迸出火花。他带着果实继续上路了。看来地球上还存在着天然的食物。  
  
![image](https://github.com/Mr-strlen/BCI_VR_Game_Demo/blob/master/Images/sence1_04.jpg)  
  
第二个场景则是旅者找到了一个房子，他可以通过观察四个角落的闪烁进行移动。  
  
![image](https://github.com/Mr-strlen/BCI_VR_Game_Demo/blob/master/Images/sence2_01.jpg)  
  
这个房子被废弃很久了，周围还能看到大机器人。   
  
![image](https://github.com/Mr-strlen/BCI_VR_Game_Demo/blob/master/Images/sence2_02.jpg) 
![image](https://github.com/Mr-strlen/BCI_VR_Game_Demo/blob/master/Images/sence2_03.jpg)  
  
旅者需要找到房子中的宝箱，然后离开这个地方。  
  
![image](https://github.com/Mr-strlen/BCI_VR_Game_Demo/blob/master/Images/sence2_04.jpg)  
  
场景中的功能设计主要基于SSVEP-BCI。通过分析脑电信号，我们可以判断用户是否在注视箱子，水桶，果实这三种不同频率的闪烁。以此作为开启下一个场景的开关，实现脑机的交互。  


## 写在最后的话
上传这个项目的时候已经是2020的七月底，2020年并不太平，我大学这四年也一样。  
因为对神经工程的兴趣，我在大一下遇到了想哥，得以遇见张老师以及后来不断教导我的各位老师和学长学姐们，也因此有了这个项目。  
很感谢能在大学期间遇到各位！！！  
  
这个项目虽然做了两年，但是并不顺利：组员变更，任务修改，状况不断，甚至曾因种种原因，一度陷入了停滞。  
后来，在组里大家的努力，老师的协助，朋友的支持下，我们还是完成了这个课题。  
（没错就是泽哥推着坐着轮椅的我去结项答辩的那会）
  
结项的那天我意识到，大学几年的悲观离合都是围绕着这个项目展开的，它和我密不可分。不过没过多久，现实又教会我，这种曲折真的也不算什么。  
所以，谨以此纪念那不悔的大学青春。
    
最后留给你的话：  
  
别人都祝你快乐  
  
我愿你，遍历山河，觉得人间值得  
