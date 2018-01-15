1. nodejs 特点
    * 异步
        * 节省时间
    * 回调函数
    * 单线程
        * 弱点
            * 无法利用多核CPU
            * 错误处理->程序奔溃->健壮性
            * 大量计算->CPU占用->UI渲染，异步响应

2. nodejs 应用场景
    * I/O 密集型
    * CPU 密集型

3. CommonJS 模块规范
    * 模块引用: var math = require('math');
        * 步骤：
            1. 路径分析
                * 核心模块 -> . or ..的相对路径 -> / 开头的绝对路径 -> 非路径的文件模块（自定义模块）
            2. 文件定位
                * 扩展名分析： .js, .json, .node 
                * **调用模块同步阻断式的判断文件是否存在** -> 推荐加上扩展名
            3. 编译加载
            ``` 核心模块
            require("os")
            NativeModule.require("os")
            process.binding("os")
            get_builtin_module("node_os")
            NODE_MODULE(node_os, reg_func)
            ```

            ``` 扩展模块
            require("./hello_world")
            process.dlopen("./hello_world", exports)
            uv_dlopen()/uv_dlsym() //libuv
            *nix or Windows
            ```
        * 类型
            * 核心模块
                * 编译时成二进制文件，进程启动加载进内存，省略文件定位和编译执行，并在路径分析中优先判断 -> 快
            * 文件模块
                * 运行时动态加载 -> 慢
    * 模块定义: math.js: exports.add = function() {};
    * 模块标识: 
        * 小驼峰命名
        * . or .. 相对路径
        * 绝对路径 
    * 模块调用栈
        ```
        文件模块：  javascript模块   <---  c/c++ 扩展模块
                         ^
                         |
        核心模块：  javascript模块
                         ^
                         |
                    c/c++ 内建模块
        ···
    
