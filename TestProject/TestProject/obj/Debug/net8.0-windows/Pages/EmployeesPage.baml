   M S B A M L   `   `   `  ����F  BTestProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TestProjectTestProject  5          TestProject.EmployeesPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      %localclr-namespace:TestProject  5        N� Title$  EmployeesPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $��9* �6   �� 5      $
��1.2* �6   .+�5   
   � $��1��5       )  %MaterialDesignDarkSeparatorBackground#���   5      6T   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ EmployeesDg��5         AutoGenerateColumns$ False��5      $��0��5         
IsReadOnly$
 True��5      $   HorizontalScrollBarVisibility$
 Auto=�5       � 	Resources 5      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property	 �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%N  '        '  �     �� 5      "  6   .�5      ��  � ��$	 Center=�6C   �� 5        � ��$	 Cascadia Mono)�63   �� 5!       � ��$	 14(�61   �� 5"       � ��$	 Light"�63   5#      �� 5$      "  6   .�5%      ��  � ��$	 Center=�6C   �� 5&       � ��$	 Center=�6A   5'      5(      
   Columns
 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��5+         Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5-      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5,      �� *Id+5-        5.      $# Табельный номер��5/      $
 Auto 51       50      �� *	TabNumber+51        52      $ Фио��53      $ SizeToCells 55       54      �� *
FullName+55        56      $ 
Почта��57      $ SizeToCells 59       58      �� *Email+59        5:      $ Телефон��5;      $ SizeToCells 5=       5<      �� *Phone+5=        5>      $ Дата приема��5?      $
 Auto 5A       5@      �� *
HireDate+ �� StringFormat$ {0:dd.MM.yyyy}��5A        5B      $# Дата увольнения��5C      $
 Auto 5E       5D      �� *TerminationDate+$ {0:dd.MM.yyyy}��5E        5F      $ Должность��5G      $ SizeToCells 5I       5H      �� *Position.Title+5I        5J      $ Статус��5K      $ SizeToCells 5M       5L      �� *Status+5M      5O      � 5Q   
   $��1��5R      $
��30 0q�5S      .+�5U      �� -   5         ��Name$ SettingsBtn��5V       + 'MaterialDesignFloatingActionLightButton#���  5W      $��40��5X      $��40��5Y      
�������$
��Left=�5[      $	��5 0q�5\      $��5q�5]      $��Center=�5^      .��5`      �� $��UniformToFill=�5a      $��/Assets/settings.png��5b      5c      �� 5e      -   5        $ AddEmployeeBtn��5f       # MaterialDesignRaisedLightButton#���  5g      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��5h      $%��Приём сотрудника��5i      
�������$��Center=�5k      $
��35 0q�5l      $��Center=�5m      5n      �� 5p      -   5        $ DeleteEmployeeBtn��5q       " MaterialDesignRaisedDarkButton#���  5r      $ 15��5s      $��Уволить��5t      $
��35 0q�5u      $��Right=�5v      $��Center=�5w      5x      5y      5z      5{      