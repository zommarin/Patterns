﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zommarin.Patterns.MVVM.ViewModel;

namespace Zommarin.Patterns.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IMainWindowView
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel.View = this;
        }

        private MainWindowViewModel ViewModel { get { return ((MainWindowViewModel) DataContext); } }
    }
}
