   M S B A M L   `   `   `  ����R  N01_TaskManager_Homework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:_01_TaskManager_Homework_01_TaskManager_Homework  5   	   )    #_01_TaskManager_Homework.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:_01_TaskManager_Homework     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � 
����� � � ColumnDefinitions 5
   
   �� 5      $
��310* �6   �� 5      $
��145* �6   �� 5      $
��337* �6    � RowDefinitions 5   
   �� 5      $
��115* �6   �� 5      $
��304* �6   .+�5   
   �� -   5         ��Name$ tbProcessName��5   �   $��40��6   $
��20 0q�6   $��3��6,   $��Center=�6@   $��Center=�6b   $��22(�6�   6�   �� 5   
   $��1��6   .+�5   
   �� $%��List of available applications:��6   �� 5   
   -   5         ��Name$ lbAccess��5      6%   5      �� 5   
   $��1��6   $��1��6"   .+�5      �� -   5        $��Start��5      $��40��6%   $��10 10 10 10q�61   6F   �� 5      -   5        $
��Stop��5      $��40��6$   $��10 10 10 10q�60   6E   5      �� 5!   
   $��1��6   $��2��6"   .+�5"      �� $$��List of running applications: ��6   �� 5#      -   5        $ lbOpened��5#      6(   5$      5'      5(      