   M S B A M L   `   `   `  ����G  CConrolFamily, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ConrolFamilyConrolFamily  5   	   !    ConrolFamily.ViewStatistics   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ConrolFamily     5   	     � Title$1  +Переглянути статистику��5   	   $	��500��6(   $	��800��68   $	��500��6G   $	��800��6T    � WindowStartupLocation$ Manual=�5	   	    � Left$	 400��6(   
 � Top$	 200��63   .��5
      � ���	#FFFAFAFA � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $��60 �6   �� 5      $��20 �6   .+�5   
   � $��0��6   $��5q�5       � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      �� 5      $
��Auto �6#   �� 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6   $��5q�6$   $3��-Виберіть початкову дату:��5      (  "System.Windows.Controls.DatePicker  5      -   5          Name$ StartDatePicker��5      $��1��62    � Language$ uk-UA�6B      FirstDayOfWeek$ Monday=�6S   $��5 0 5 0q�6k   	 � 	Resources	 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox
 �� 
TargetType �� Property �� Value��%W   '        �� 5      "
  6   .�5       ��  � ��$ 1,1,0,0q�63   5!      5"      5#      �� 5$      $��2��6   $��5q�6$   $/��)Виберіть кінцеву дату:��5%        5&      -   5        $ EndDatePicker��5&      $��3��60   $ Monday=�6@   $��5 0 5 0q�6X   	 5'      ��%W   '        �� 5(      "
  6   .�5)      ��  � ��$ 1,1,0,0q�63   5*      5+      5,      �� 5-      -   5        $1��+Переглянути статистику��5-      $��5��66   $��	10 0 10 0q�6e   ���#00695C
�������6�   5.      &   System.Windows.Controls.DataGrid  5/   
   -   5          Name$ dgGrid��5/      $��1��50      $��5q�51         AutoGenerateColumns$ False��52         
IsReadOnly$
 True��53         Columns 54      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Назва��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 244 57   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 58   %   �� *Name+  59      $ Сума��6%   $	 240 5:   %      ElementStyle 5;      �� 5<      "
 ��6    .�5=      ��  � ��
 �   �6;   �� 5>       � �� 65   �� *Amount+ �� StringFormat$ {0:#.##}�� �� Triggers 5?      �� 5@   "    �� Binding 6.   �� *
Category+ �� Value
 Income6K   .a�5A   &   ��  � ��
 � � �6C   �� 5B   &    � �� 6=   �� *Amount+$ 
 +{0:#.##}��5C   #   �� 5D   "    6.   �� *
Category+ Expense6K   .a�5E   &   ��  � ��
 �  ��6C   �� 5F   &    � �� 6=   �� *Amount+$ 
 -{0:#.##}��5G   #   5I      5K        5L      $ Дата��6%   $ * 5M   %    5N   %   �� *Date+$ {0:dd.MM.yyyy}��5P      � 5Q   
   $��2��6   ���	#FFFAFAFA 5R      �� 5S      $��30 �6   �� 5T      $��30 �6    5V      �� 5W      $
��Auto �6#   �� 5X      $��* �6#   �� 5Y      $
��Auto �6#   �� 5Z      $��* �6#   .+�5\      �� $��0��6   $6��0Загальний дохід за період:��6$   $��5,1,0,0q�6I   �� 5]      -   5         ��Name$ TotalIncome��5]   (   $��1��6   $��Center=�6=   $��5q�6X   
��� � �6d   �� 5^      $��2��6   $8��2Загальні витрати за період:��6$   $��5,1,0,0q�6J   �� 5_      -   5        $ TotalExpense��5_   (   $��3��6   $��Center=�6>   $��5q�6Y   
���  ��6e   �� 5`      $��1��6   $��0��6!   $8��2Загальний баланс за період:��61   $��5,1,0,0q�6W   �� 5a      -   5        $ TotalBalance��5a   5   $��1��6   $��1��6%   $��Center=�6K   $��5q�6f   5b      �� 5c   
   $��3��6   ���	#FFFAFAFA.@�5d      �� -   5        $ tbStatus��5d      5e      5f      5g      