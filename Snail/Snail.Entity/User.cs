using System;
//-----------------------------------------------------------------------
// * Copyright (C) 蜗牛科技
// * Version : V1.0
// * Author  : Allon
// * FileName: User.cs
// * History : Created by T4 12/09/2019 14:05:17
// </copyright>
//-----------------------------------------------------------------------
namespace Snail.Entity
{
	public class User
    {
       //[SugarColumn(ColumnName="ID" , IsPrimaryKey = true, IsIdentity = true )]
       public  int  ID  { get; set; }
       //[SugarColumn(ColumnName="Name"  )]
       public  string  Name  { get; set; }
       //[SugarColumn(ColumnName="Age"  )]
       public  int?  Age  { get; set; }
    }
}
