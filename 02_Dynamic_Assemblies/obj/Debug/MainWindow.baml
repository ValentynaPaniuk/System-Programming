   M S B A M L   `   `   `  ����O  K2_Dynamic_Assemblies, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:_2_Dynamic_Assemblies_2_Dynamic_Assemblies  5   	   &     _2_Dynamic_Assemblies.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:_2_Dynamic_Assemblies     5   	     � Title$  
MainWindow��5   	   $	��347��6   $	��800��6)   .��5	      � $��20q�6   
������� � ColumnDefinitions 5
   
   �� 5      $
��255* �6   �� 5      $
��205* �6   �� 5      $
��332* �6    � RowDefinitions 5   
   �� 5      $	��95* �6   �� 5      $
��181* �6   .+�5   
   �� .+�5      �� -   5        $��Load assembly��5      $��10q�6-   69   �� 5      -   5        $��
lb_library��5      $��10q�6&   5      �� 5   
   $��List of classes:��6   $��0��6+   $��Bottom=�6;   $��26��6V   �� 5   
   -   5        $��lb_Assemblies��5      $��1��6'   
�������6L   �� 5   
   -   5        $��	lb_Method��5      $��List of available methods��6!   $��1��6E   $��Bottom=�6U   $��26��6p   �� 5   
   -   5        $��
lb_Methods��5      $��1��6$   $��1��64   
���i��6A   �� 5    
   -   5        $��spParameters��5    3   $��2��6   $��0��6%   6I   �� 5#   
   $��2��6   $��1��6%   
�������.+�5%      �� -   5         ��Name$ 	lblResult��5%      $��2��6'   $��
Result:   ��64   $��20(�6I   $��Center=�6W   $��Center=�6t   5'      �� 5(   
   -   5        $	��Run��5(      $��107,0,108,10q�61   $��2��6G   $��1��6W   $��20��6d   $��Bottom=�6p   5+      5,      