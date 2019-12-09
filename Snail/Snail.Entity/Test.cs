using System;
//-----------------------------------------------------------------------
// * Copyright (C) 蜗牛科技
// * Version : V1.0
// * Author  : Allon
// * FileName: Test.cs
// * History : Created by T4 12/09/2019 14:05:17
// </copyright>
//-----------------------------------------------------------------------
namespace Snail.Entity
{
	public class Test
    {
       //[SugarColumn(ColumnName="Id" , IsPrimaryKey = true )]
       public  Guid  Id  { get; set; }
       //[SugarColumn(ColumnName="Name"  )]
       public  string  Name  { get; set; }
       //[SugarColumn(ColumnName="Amount"  )]
       public  string  Amount  { get; set; }
    }
}
