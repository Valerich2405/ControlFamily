   M S B A M L   `   `   `  ����G  CConrolFamily, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ConrolFamilyConrolFamily  5   	   ;"clr-namespace:ControlFamily.ModelsControlFamily.Models  5   	   (    "ConrolFamily.RecordingIncomeWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ConrolFamily     5   	   5Models"clr-namespace:ControlFamily.Models     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  Додати дохід��5
   	   $	��400��6   $	��800��6.   $	��400��6=   $	��800��6J    � WindowStartupLocation$ Manual=�5   	    � Left$	 400��6(   
 � Top$	 200��63   .��5      � ���	#FFFAFAFA � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $��30 �6   .+�5   
   � $��0��6   $��5q�5       � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      �� 5      $
��Auto �6#   �� 5      �� 5      $
��Auto �6#   �� 5      �� 5      $	��100 �6#   .+�5      �� $��0��6   $��Назва:��5      $��5q�5      �� 5       -   5         ��Name$ NameIncomeTxt��5!      $��1��5       $��5 0 5 0q�6&   $��Center=�5"      �� 5#       J� IsHitTestVisible$ False��6   $��12(�61   $-��'Введіть назву доходу:��6?   $��1��6\   $��5 0 5 0q�6l   $��Center=�6}   
���������5$      �� 5%       �� 
TargetType" ��6   .�5&      �� 	 �� Property	 � y�
 �� Value$
 	Collapsed=�67    �� Triggers 5'      �� 5(       �� Binding 6*   �� *Text+ �� ElementName$ NameIncomeTxt�� �� Value  6^   .a�5)   "   �� 	 � y�$
 Visible=�6?   5*      5,      5.      �� 5/      $��2��6   $��	Сума:��50      $��5q�51      �� 52      -   5        $ AmountIncomeTxt��53      $��3��52      $��5 0 5 0q�6&   $��Center=�54      �� 55      $ False��6   $��12(�61   $+��%Введіть суму доходу:��6?   $��3��6[   $��5 0 5 0q�6k   $��Center=�6|   
���������56      �� 57      " ��6   .�58      �� 	 � y�$
 	Collapsed=�67    59      �� 5:       6*   �� *Text+$ AmountIncomeTxt��  6`   .a�5;   "   �� 	 � y�$
 Visible=�6?   5<      5>      5@      �� 5A      $��4��6   $��	Дата:��5B      $��5q�5C      (  "System.Windows.Controls.DatePicker  5D      -   5          Name$ IncomeDatePicker��5D      $��5��63    � Language$ uk-UA�6C      FirstDayOfWeek$ Monday=�6T   $��0 9 5 0q�6l    � 	Resources 5E      :  4System.Windows.Controls.Primitives.DatePickerTextBox��%}   '        �� 5F      "  6   .�5G      �� 	 � ��$
 1,1,0,0q�63   �� 5H      	 � ��

 � � �68   5I      5J      5K      �� 5L      -   5        $��	AddButton��5N      $��6��5L      $��5 0 5 0q�5M      $��Додати��5O      ���#00695C   MaterialDesignRaisedButton#��[  5R      
�������6I   5S      &   System.Windows.Controls.DataGrid  5T   
   -   5          Name$ dgGrid��5T      $��1��5U      $��5q�5V         AutoGenerateColumns$ False��5W         
IsReadOnly$
 True��5X         Columns 5Y      0  *System.Windows.Controls.DataGridTextColumn  5[      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Назва��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 244 5\   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5]   %   �� *
NameIncome+  5^      $ Сума��6%   $	 240 5_   %      
Foreground
 � � � 5`   %   �� *AmountIncome+ �� StringFormat$ 	+{0:#.##}��5a   %     5b      $ Дата��6%   $ * 5c   %    5d   %   �� *
DateIncome+$ {0:dd.MM.yyyy}��4  .System.Windows.Controls.DataGridTemplateColumn  5e      $ Видалити��6)   $	 100 5f   )      CellTemplate 5g      �� 5h      .R�5i      �� -   5        $��	5 -5 5 -5q�5j   %   ���#00695C5k   %   5l      5n      5p      �� 5q   
   $��2��6   ���	#FFFAFAFA.@�5r      �� -   5         ��Name$ tbStatus��5r      5s      5t      5u      