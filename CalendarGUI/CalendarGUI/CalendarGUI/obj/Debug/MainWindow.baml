   M S B A M L   `   `   `  ����F  BCalendarGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:CalendarGUICalendarGUI  5   	       CalendarGUI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:CalendarGUI     5   	     � Title$  
MainWindow��5   	   $	��200��6   $	��350��6)   .��5	      � -   5        $��pnlMainGrid��5	      
����ح� � ColumnDefinitions 5
   
   �� 5      $	��59* �6   �� 5      $
��283* �6   .+�5   
   �� -   5         ��Name$ TXB_1��5      $
��Left=�6!   $��20��6<   $��
136,40,0,0q�6H    �� TextWrapping$
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $��99��6�   $��1��6�   �� 5   
   -   5        $ TXB_2��5      $
��Left=�6!   $��20��6<   $��
136,65,0,0q�6H   $
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $��99��6�   $��1��6�   �� 5   
   $
��Left=�6   $��20��6/   $��	20,40,0,0q�6;   $
��Wrap=�6N   $��ID��6b   $	��Top=�6l   $��96��6�   $��2��6�   �� 5   
   $
��Left=�6   $��20��6/   $��	20,65,0,0q�6;   $
��Wrap=�6N   $
��Name��6b   $	��Top=�6n   $��96��6�   $��2��6�   �� 5   
   -   5         ��Name$ submit��5      $��Submit��6!   $
��Left=�62   $��
20,129,0,0q�6M   $	��Top=�6a   $��75��6y   $��2��6�   �� 5   
   $
��Left=�6   $��34��6/   $��	20,90,0,0q�6;   $
��Wrap=�6N   $��Date (YYYY-MM-DD)��6b   $	��Top=�6{   $	��118��6�   $��2��6�   �� 5   
   -   5        $ TXB_3��5      $
��Left=�6!   $��20��6<   $��
136,90,0,0q�6H   $
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $��99��6�   $��1��6�   �� 5   
   -   5        $
 Show��5      $��Show events��6   $
��Left=�65   $��
72,129,0,0q�6P   $	��Top=�6d   $��75��6|   $��1��6�   �� 5   
   -   5        $ Clear��5      $��Clear events��6    $
��Left=�67   $��172,129,0,0q�6R   $	��Top=�6g   $��75��6   $��1��6�   5      5      