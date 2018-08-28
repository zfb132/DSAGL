# 数据结构与算法实验要求
部分代码源自课本讲义
---
新建空白解决方案 `exp.sln`  
## 实验一：数组和类的定义与项目的管理
在新的解决方案中新建一个控制台应用程序类型的项目**exp1app**  
* 定义一个含`Main`方法的类`ArrayTest.cs`，在其中定义和随机初始化一个具有20个元素、值域在-99到99的整数数组，在数组中查找特定数据，对数组中的数据进行排序。重新随机初始化数组，对数组中的数据按绝对值大小进行排序
* 定义一个含`Main`方法的类`GenericList.cs`，在其中利用`List<T>`类定义和初始化一个int类型的线性表，在表中添加`Add`和插入`Insert`新的元素；定义一个自定义`Student`类，定义和初始化一个`Student`类型的线性表，在表中添加`Add`和插入`Insert`新的元素
* 定义一个含`Main`方法的类`GenericMethod.cs`，在其中利设计一个泛型方法`swap`，能交换不同类型的两个变量的值
* 设计定义一个复数类`Complex.cs`，实现复数的基本操作
* 定义一个含`Main`方法、测试复数类的类`ComplexTest.cs`，测试复数的基本操作
* 定义一个含`Main`方法的类`FileStreamTest.cs`，在其中打开、读入文本文件，将其内容逐行输出到一个新文件，实现文件的拷贝，记录和显示拷贝过程的时间
## 实验二：线性表的设计与实现
在解决方案中新建一个控制台应用程序类型的项目**exp2app**和类库型项目**exp2lib**  
* 在**exp2app**中定义一个含`Main` 方法的类`GenericList.cs`，在其中利用`List<T>`类定义和初始化一个int 类型的线性表，在表中添加`Add`和插入`Insert`新的元素；定义一个自定义`Student` 类，定义和初始化一个`Student`类型的线性表，在表中添加`Add`和插入`Insert`新的元素
* 在**exp2lib** 中编程实现一个包含起标志作用的头结点的单向链表类。它的头结点不包含数据元素，仅起标志作用，头结点的链指向链表的第一个数据结点；设计泛型链表类`SingleLinkedList` 和结点类和`SingleLinkedNode`
* 使用线性表类求解**约瑟夫Josephus环问题**
## 实验三：栈与队列的设计与实现
在解决方案中新建一个控制台应用程序类型的项目**exp3app**和类库型项目**exp3lib**  
* **数制转换**：在**exp3app** 中定义一个含`Main` 方法的类
`Dec2Hex.cs`，在其中利用`Stack<T>`类定义和初始化一个int 类型的栈对象，将10 进制整数转换为16 进制整数，输出结果
* **利用队列和栈将一个序列反序**：在**exp3app** 中定义一个含`Main` 方法的类`Queue2Stack.cs`，在其中利用`Queue<T>`类定义和初始化一个int 类型的队列对象，借用一个栈对象将队列中的原序列反序，输出反序后的结果
* 在**exp3lib**中编程实现自定义栈类`SequencedStack`与队列类`SequencedQueue`
* **表达式求值**：将中缀表达式转换为后缀表达式，再求后缀表达式的值
## 实验四：树与二叉树的设计与实现
在解决方案中新建一个控制台应用程序类型的项目**exp4app**和类库型项目**exp4lib**  
* 在**exp4lib** 中编程实现自定义链式存储的二叉树结点类
`BinaryTreeNode` 和二叉树类`BinaryTree`，实现先根、中根和后根次序遍历和按层次遍历二叉树的操作；在二叉树类`BinaryTree` 的定义中， 编程实现静态方法`ByOneList(IList<T> t)`，参数`t` 表示顺序存储的完全二叉树结点值序列，由此建立链式存储结构的完全二叉树
* 在**exp4app** 中编写一个测试程序`BinaryTreeTest`，构建一颗二叉树实例，输出先根、中根、后根次序及按层次遍历得到的序列；编写一个测试程序`ByOneListTest`，构建一颗完全二叉树实例，输出先根、中根、后根次序及按层次遍历得到的序列
* 在二叉树类`BinaryTree` 的定义中，编程实现静态方法`ByOneList(IList<T> sList, ListFlagsStruc<T> ListFlags)`，它的第一个参数是二叉树的广义表表示式，第二个参数定义广义表表示式所用的分界符，该方法根据特定的广义表表示式建立链式存储结构的二叉树；在**exp4app** 项目中编写一个测试程序`ByOneListGTest`，构建一颗二叉树实例，输出先根、中根、后根次序及按层次遍历得到的序列
* 编写一个Windows 窗体应用程序**exp4xapp**：包括以下`MenuStrip`、`TreeView`等控件
## 实验五：查找表结构和算法的设计与实现
在解决方案中新建一个控制台应用程序类型的项目**exp5app**和类库型项目**exp5lib**  
* 在**exp5app**中定义一个含`Main` 方法的类`SearchInArray.cs`，在其中定义和随机初始化一个具有5000 个元素、值域在0 到999 的整数数组，在数组中查找指定值的20 个数据；对数组中的数据进行排序，然后在数组中二分查找这20 个数据并比较两种查找算法所花费的不同时间
* 在上一步的基础上将数组改为`Dictionary`并比较这两种数据结构下花费时间的不同
* 在**exp5lib** 中编程实现自定义的顺序查找表类`LinearSearchList`，实现其中的造表`Add`，`Insert`、顺序查找`IndexOf`、二分查找 `BinarySearch`算法；在**exp5app** 项目中定义一个含`Main` 方法的测试类`LinearSearchListTest.cs`，在其中定义和随机初始化一个查找表，测试顺序查找和二分查找算法
* 在**exp5lib**中设计并编程实现自定义的哈希链表类`HashSearchList`，实现其中的造表与查找算法`Hash`，`Add`, `Search`；在**exp5app**项目中定义一个含`Main` 方法的测试类`HashSearchListTest.cs`，在其中定义和随机初始化一个`Hash` 查找表，测试`Hash` 查找算法
* 编写一个Windows 窗体应用程序**exp5xapp**：其中编写一份XML 文件`robots.xml`，包含一组数据，具有`ID`、`Name`、`IQ` 等字段；该应用程序可以让用户通过姓名查找相应的数据（利用**LINQ**语句）
## 实验六：排序算法的实现与分析
在新的解决方案中新建一个控制台应用程序类型的项目**exp6app**和类库型项目**exp6lib**  
* 在**exp6app**中定义一个含`Main` 方法的类`SortArrayTest.cs`，在其中定义和随机初始化一个具有20 个元素、值域在-99 到99 的整数数组，对数组中的数据进行排序；重新随机初始化数组，对数组中的数据按绝对值大小进行排序
* 在**exp6app** 中定义一个含`Main` 方法的类`SortArrayByTest.cs`，在其中定义一个`Robot` 类型的数组并初始化，然后按`Robot` 的不同字段进行排序；自定义一个`Robot` 类型及各种比较的方式`Robot.cs`
* 在**exp6lib**中编程实现自定义的排序算法类`Sort`，实现
`InsertSort`、`BubbleSort`、`QuickSort` 和`SelectSort` 等算法；在**exp6app**中定义一个含Main 方法的测试类`SortAlgorithmTest.cs`，测试不同的排序算法
* 编写一个Windows 窗体应用程序**exp6xapp**：在实验五的基础上增加功能可以让用户通过菜单选择按不同的关键字对数据进行排序
