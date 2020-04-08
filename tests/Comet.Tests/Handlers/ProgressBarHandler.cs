﻿using System.Drawing;

namespace System.Maui.Tests.Handlers
{
	public class ProgressBarHandler : GenericViewHandler
	{
		public ProgressBarHandler()
		{
			OnGetIntrinsicSize = HandleOnGetIntrinsicSize;
		}

		public Slider VirtualView => (Slider)CurrentView;

		private SizeF HandleOnGetIntrinsicSize(SizeF arg) => new SizeF(100, 20);
	}
}
