﻿using System;
using System.Maui.Internal;
using Xunit;

namespace System.Maui.Tests
{
	public class HotReloadTests : TestBase
	{

		public class MyOrgView : View
		{
			public const string TextValue = "Hello!";
			public MyOrgView()
			{
				this.Body = () => new Text(TextValue);
			}
		}
		public class MyNewView : View
		{
			public const string TextValue = "Goodbye!";
			public MyNewView()
			{
				this.Body = () => new Text(TextValue);
			}
		}

		public HotReloadTests()
		{
			HotReloadHelper.IsEnabled = true;
		}

		[Fact]
		public void HotReloadRegisterReplacedViewReplacesView()
		{
			var orgView = new MyOrgView();
			var orgText = orgView.GetView() as Text;
			Assert.Equal(MyOrgView.TextValue, orgText.Value.CurrentValue);

			HotReloadHelper.RegisterReplacedView(typeof(MyOrgView).FullName, typeof(MyNewView));
			var newText = orgView.GetView() as Text;

			Assert.Equal(MyNewView.TextValue, newText.Value.CurrentValue);

		}
	}
}
