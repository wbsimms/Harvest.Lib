﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using ProduceForHarvest.Model;

namespace ProduceForHarvest.ViewModel
{
	public class ViewModelLocator
	{

		static ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			var nav = new NavigationService();
			SimpleIoc.Default.Register<INavigationService>(() => nav);

			SimpleIoc.Default.Register<IDialogService, DialogService>();

			if (ViewModelBase.IsInDesignModeStatic)
			{
				SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
			}
			else
			{
				SimpleIoc.Default.Register<IDataService, DataService>();
			}

			SimpleIoc.Default.Register<MainViewModel>();
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
			"CA1822:MarkMembersAsStatic",
			Justification = "This non-static member is needed for data binding purposes.")]
		public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
	}
}
