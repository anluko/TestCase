   M S B A M L   `   `   `  ����F  BTestProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TestProject.PagesTestProject.Pages  5      !    TestProject.Pages.StatsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TestProject.Pages     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  	StatsPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $	��17* �6   �� 5      $	��87* �6   �� 5      $	��13* �6   .+�5   
   �� -   5         ��Name$ StatFilters��5      $y�	Collapsed=�5      
���   �$��1q�5      ._�5      � $��100 0q�5      $��Center=�5       *  &MaterialDesignLightSeparatorBackground#���   5      .+�5      ��  �� Orientation$ 
Horizontal=�5      $
��Left=�5      $��Center=�5       $
��30 0q�5!      .+�5#      (  "System.Windows.Controls.DatePicker  -   5          Name$ StartDp��5$       ( $MaterialDesignFloatingHintDatePicker#���  5%      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Дата приёма��5&      $
��10 0q�5'      $��14(�5(      $��Cascadia Mono)�5)      5*        5,      -   5        $ EndDp��5-      #���  5.      $# Дата увольнения��5/      $
��20 0q�50      $��14(�51      $��Cascadia Mono)�52      53      54      �� 56      -   5         ��Name$ DepartmentsCb��57       & "MaterialDesignFloatingHintComboBox#���  58      $1 +Выберите подразделение��59      &   FloatingHintHorizontalAlignment$
 Left=�5:         
IsFloating$
 True��5;      $��16(�5<      $��0��5=      $��3��5>      $
��30 0q�5?      $��Center=�5@      $��Right=�5A      $��Center=�5B      5C      5D      5E      &   System.Windows.Controls.DataGrid  5G   
   -   5        	  Name$	 EmployeesDg��5H      $y�	Collapsed=�5I      
   AutoGenerateColumns$
 False��5J      $��1��5K         
IsReadOnly$
 True��5L      $   HorizontalScrollBarVisibility$
 Auto=�5M       � 	Resources 5O      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%N  '        '  �     �� 5P      "  6   .�5Q      ��  � ��$ Center=�6C   �� 5R       � ��$ Cascadia Mono)�63   �� 5S       � ��$ 14(�61   �� 5T       � ��$ Light"�63   5U      �� 5V      "  6   .�5W      ��  � ��$ Center=�6C   �� 5X       � ��$ Center=�6A   5Y      5Z         Columns 5[      0  *System.Windows.Controls.DataGridTextColumn  5\      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��5]         Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5_      1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 5^      �� *Id+5_        5`      $# Табельный номер��5a      $
 Auto 5c       5b      �� *	TabNumber+5c        5d      $ Фио��5e      $ SizeToCells 5g       5f      �� *
FullName+5g        5h      $ Дата приема��5i      $
 Auto 5k       5j      �� *
HireDate+ �� StringFormat$ {0:dd.MM.yyyy}��5k        5l      $# Дата увольнения��5m      $
 Auto 5o       5n      �� *TerminationDate+$ {0:dd.MM.yyyy}��5o        5p      $ Должность��5q      $ SizeToCells 5s       5r      �� *Position.Title+5s        5t      $ Статус��5u      $ SizeToCells 5w       5v      �� *Status+5w      5y      �� 5{   
   -   5         ��Name$ StatsSp��5|      $y�	Collapsed=�5}      $��2��5~      $ 
Horizontal=�5      $��Center=�5�      $��Center=�5�      .+�5�      �� -   5         ��Name$ TakedEmployeesTbk��5�      $0��*Принято сотрудников: {0}��5�      �� 5�      -   5        $ DissmissedEmployeesTbk��5�      $0��*Уволено сотрудников: {0}��5�      $
��50 0q�5�      5�      �� 5�   
   -	   5        $��SelectFileSp��5�      $y�	Collapsed=�5�      $��3��5�      $��Center=�5�      $��Center=�5�      .+�5�      �� $��18(�5�      $H��BПеретащите сюда excel-файл для импорта��5�      �� 5�      -
   5        $��DragDropArea��5�      $	��100��5�      
�������$��2q�5�      
������� J� 	AllowDrop$
 True��5�      $
��0 30q�5�      ._�5�      �� $,��&Перетащите файл сюда��6   $��Center=�5�      $��Center=�5�      
�������5�      5�      �� 5�      $ 
Horizontal=�5�      $��Stretch=�5�      $��Center=�5�      .+�5�      �� $!��Либо вы можете ��5�      $��Center=�5�      �� 5�      -   5        $��SelectFileButton��5�       ! MaterialDesignFlatLightButton#���  5�      $��Выбрать файл��5�      $��14(�5�      $
��20 0q�5�      5�      5�      5�      �� 5�   
   -   5        $ StartLoadSp��5�      $y�	Collapsed=�5�      $��3��5�      $��Center=�5�      $��Center=�5�      .+�5�      �� $"��Выбранный файл:��5�      $��18(�5�      �� 5�      $ 
Horizontal=�5�      $��Center=�5�      $��0 30 0 0q�5�      .+�5�      �� $��20��5�      $��20��5�      $��/Assets/excel.png��5�      �� 5�      -   5        $ FileNameTbk��5�      $��	file.xlsx��5�      $��Italic$�5�      $��Center=�5�      $��14(�5�      5�      �� 5�      -   5         ��Name$ StartLoadBtn��5�        MaterialDesignRaisedButton#���  5�      +
  %MaterialDesignThemes.Wpf.ButtonAssist 
  CornerRadius$ 15��5�      $��Начать импорт��5�      $	��300��5�      $��	0 40 0 10q�5�      5�      �� 5�      -   5        $ ChooseNewFileBtn��5�         MaterialDesignOutlinedButton#���  5�      $ 15��5�      $(��"Выбрать новый файл��5�      $	��300��5�      $��0 5 0 40q�5�      5�      5�      5�      5�      