   M S B A M L   `   `   `  ����G  CConrolFamily, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ConrolFamilyConrolFamily  5   	   ;"clr-namespace:ControlFamily.ModelsControlFamily.Models  5   	   )    #ConrolFamily.RecordingExpenseWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ConrolFamily     5   	   5Models"clr-namespace:ControlFamily.Models     5   	   -   5          � Title$!  Додати витрату��5	   	   $	��400��6    $	��800��60   $	��400��6?   $	��800��6L    � WindowStartupLocation$ Manual=�5
   	    � Left$	 400��6(   
 � Top$	 200��63   .��5      � ���	#FFFAFAFA � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $��30 �6   .+�5   
   � $��0��6   $��5q�5       � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      �� 5      $
��Auto �6#   �� 5      �� 5      $
��Auto �6#   �� 5      �� 5      $	��100 �6#   .+�5      �� $��0��6   $��Назва:��5      $��5q�5      �� 5      -   5         ��Name$ NameExpenseTxt��5       $��1��5      $��5 0 5 0q�6&   $��Center=�5!      �� 5"       J� IsHitTestVisible$ False��6   $��12(�61   $/��)Введіть назву витрати:��6?   $��1��6]   $��5 0 5 0q�6m   $��Center=�6~   
���������5#      �� 5$       �� 
TargetType" ��6   .�5%      �� 	 �� Property	 � y�
 �� Value$
 	Collapsed=�67    �� Triggers 5&      �� 5'       �� Binding 6*   �� *Text+ �� ElementName$ NameExpenseTxt�� �� Value  6_   .a�5(   "   �� 	 � y�$
 Visible=�6?   5)      5+      5-      �� 5.      $��2��6   $��	Сума:��5/      $��5q�50      �� 51      -   5        $ AmountExpenseTxt��52      $��3��51      $��5 0 5 0q�6&   $��Center=�53      �� 54      $ False��6   $��12(�61   $-��'Введіть суму витрати:��6?   $��3��6\   $��5 0 5 0q�6l   $��Center=�6}   
���������55      �� 56      " ��6   .�57      �� 	 � y�$
 	Collapsed=�67    58      �� 59       6*   �� *Text+$ AmountExpenseTxt��  6a   .a�5:   "   �� 	 � y�$
 Visible=�6?   5;      5=      5?      �� 5@      $��4��6   $��	Дата:��5A      $��5q�5B      (  "System.Windows.Controls.DatePicker  5C      -   5          Name$ ExpenseDatePicker��5C      $��5��64    � Language$ uk-UA�6D      FirstDayOfWeek$ Monday=�6U   $��0 9 5 0q�6m    � 	Resources 5D      :  4System.Windows.Controls.Primitives.DatePickerTextBox��%W   '        �� 5E      "  6   .�5F      �� 	 � ��$
 1,1,0,0q�63   5G      5H      5I      �� 5J      -   5        $��AddExpenseButton��5L      $��6��5J      $��5 0 5 0q�5K      $��Додати��5M      ���#00695C   MaterialDesignRaisedButton#��[  5P      
�������6I   5R      &   System.Windows.Controls.DataGrid  5S   
   -   5          Name$ dgGrid��5S      $��1��5T      $��5q�5U         AutoGenerateColumns$ False��5V         
IsReadOnly$
 True��5W         Columns 5X      0  *System.Windows.Controls.DataGridTextColumn  5Z      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Назва��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 244 5[   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5\   %   �� *NameExpense+  5]      $ Сума��6%   $	 240 5^   %      
Foreground
 �  �� 5_   %   �� *AmountExpense+ �� StringFormat$ 	-{0:#.##}��5`   %     5a      $ Дата��6%   $ * 5b   %    5c   %   �� *DateExpense+$ {0:dd.MM.yyyy}��4  .System.Windows.Controls.DataGridTemplateColumn  5d      $ Видалити��6)   $	 100 5e   )      CellTemplate 5f      �� 5g      .R�5h      �� -   5        $��	5 -5 5 -5q�5i   %   ���#00695C5j   %   5k      5m      5o      �� 5p   
   $��2��6   ���	#FFFAFAFA.@�5q      �� -   5         ��Name$ tbStatus��5q      5r      5s      5t      