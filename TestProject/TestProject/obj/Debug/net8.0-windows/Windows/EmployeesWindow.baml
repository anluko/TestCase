   M S B A M L   `   `   `  ����F  BTestProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TestProject.WindowsTestProject.Windows  5   	   )    #TestProject.Windows.EmployeesWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -local!clr-namespace:TestProject.Windows  5   	     � Title$  Сотрудники��5	   	   $	��500��6   $	��800��6)   $	��400��65   $	��600��6E   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��30* �6   �� 5      $
��100* �6   �� 5      $	��59* �6    � RowDefinitions 5   
   �� 5      �� 5      $��6* �6   .+�5   
   � $��3��5       )  %MaterialDesignDarkSeparatorBackground#���   5      6T   �� 5   
   -   5         ��Name$ SearchTb��5      $y�Visible=�5      $��0��5      $��2��5       ! MaterialDesignOutlinedTextBox#���  5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$+ %Введите сотрудника..��5      $��16(�5       $��30��5!      $
��50 0q�5"      $��Center=�5#      $��Center=�5$      $
��15 0q�5&      �� 5(   
   -   5         ��Name$ DepartmentsCb��5)      $y�Visible=�5*       & "MaterialDesignFloatingHintComboBox#���  5+      $1 +Выберите подразделение��5,      &   FloatingHintHorizontalAlignment$
 Left=�5-         
IsFloating$
 True��5.      $��16(�5/      $��0��50      $��3��51      $��Center=�52      $��Center=�53      $
��20 0q�54      55      �� 57   
   -   5         ��Name$ BackBtn��58       % !MaterialDesignFlatSecondaryButton#���  59      +  %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 15��5:      $y�	Collapsed=�5;      $��20(�5<      $��
Назад��5=      
���   �$��Center=�5?      $��Center=�5@      5A      �� 5C   
   -   5        
 ��Name$
 InfoTbk��5D      $<��6Добавление нового сторудника��5E      $y�	Collapsed=�5F      $��0��5G      $��3��5H      $��Center=�5I      $��Center=�5J      $��22(�5K      � 5M   
   -   5         �Name$ StatsLoadGrid��5N      $y�	Collapsed=�5O      $��0��5P      $��1��5Q      $��2��5R      $��Stretch=�5S      $��Center=�5T      $
��50 0q�5U      .+�5W      �� -   5        $ ShowStatsBtn��5X      $��1��5Y       # MaterialDesignRaisedLightButton#���  5Z      $	 15��5[      $+��%Показать статистику��5\      
�������$
��Left=�5^      $
��35 0q�5_      $��Center=�5`      5a      �� 5b      -   5        $ ShowLoadBtn��5c      $��1��5d      #���  5e      $	 15��5f      $%��Загрузить данные��5g      
�������$��Right=�5i      $
��35 0q�5j      $��Center=�5k      5l      5n       � 5p   
   -   5          �Name$ 	MainFrame��5q      $��1��5r      $��3��5s        � NavigationUIVisibility$ Hidden=�5t      5u      5v      