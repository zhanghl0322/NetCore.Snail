# NetCore.Snail
# 蜗牛
# I.框架概述
 1).NetCore.Snail 是一个前后端分离通用权限系统， 用vs2017+sqlserver2008开发工具。
 2).后端标准三层结构：基于NETStandard2.0标准类库。Api使用Asp.Net Core webapi,jwt身份认证。

# II.结构概述
 1).Snail.WebApi    主项目层(文件夹Admin和Client，分别用来存放后台和前台的接口)
 
 1).Snail.IService  数据接口层(该层为数据接口层，里面只罗列了相应的接口函数，
 但是具体的函数功能实现则交给继承该数据接口的数据层来实现。)
 
 3).Snail.Service   数据层(该层负责直接或者间接对数据库进行操作，
 如果你是用原生的或者类似Dapper的数据库中间件，那么在这一层就会看到相应的sql语句)
 
 4).Snail.Model     模型层(该层存放了一些系统帮助类，或是实体辅助类)
 
 5).Snail.Entity    实体层(该层为实体类层，存储了数据库对应的所有实体，实体一般和数据库表是相互对应)
 
 5).Snail.Bussiness 业务逻辑层(该层只做业务逻辑的相关运算)
 
 6).Snail.Common    公共类
