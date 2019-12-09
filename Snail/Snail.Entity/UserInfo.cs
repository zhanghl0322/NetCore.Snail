using System;
//-----------------------------------------------------------------------
// * Copyright (C) 蜗牛科技
// * Version : V1.0
// * Author  : Allon
// * FileName: UserInfo.cs
// * History : Created by T4 12/09/2019 14:05:17
// </copyright>
//-----------------------------------------------------------------------
namespace Snail.Entity
{
	public class UserInfo
    {
       //[SugarColumn(ColumnName="Id" , IsPrimaryKey = true, IsIdentity = true )]
       public  int  Id  { get; set; }
       //[SugarColumn(ColumnName="UserId"  )]
       public  int?  UserId  { get; set; }
       //[SugarColumn(ColumnName="City"  )]
       public  string  City  { get; set; }
    }
}
