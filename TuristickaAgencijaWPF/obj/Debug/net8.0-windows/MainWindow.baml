   M S B A M L   `   `   `  ����P  LTuristickaAgencijaWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TuristickaAgencijaWPFTuristickaAgencijaWPF  5   	   &     TuristickaAgencijaWPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:TuristickaAgencijaWPF     5   	     � Title$  Turistička agencija��5   	   $	��450��6%   $	��800��62   
������� � 	Resources 5
         Buttons �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%D  &	        �� 5   
   " ��6    .�5      ��  � ��
 ���� 6B   �� 5       � ��$ 14(�6)   66   �� 5       � ��$ 0q�60   6<   �� 5       � ��$ 5,0,5,0q�6'   69    5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � ��
 �� ��63   5      5      5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGridCentralni��5      $��Center=�6,   $��Center=�6G   $
��auto��6d   $
��auto��6r      
IsReadOnly$
 True��6   	   AlternatingRowBackground
	 �����
   CanUserAddRows$
 False��5   1      SelectionUnit$ FullRow=�6H      SelectionMode$ Single=�6`   �� 5   
   $��Center=�6   $��30��62   $	��Top=�6?   $
��auto��6W    �� Orientation$ 
Horizontal=�6d   .+�5      �� -   5        $��btnPutovanje��5      $��	Putovanje��6)   #��[  6>   $
��Left=�6`   $��30��6{   $	��Top=�6�   $��75��6�   6�   �� 5      -   5        $��btnRezervacija��5      $��Rezervacija��6+   #��[  6A   $
��Left=�6b   $��30��6}   $	��Top=�6�   $��75��6�   6�   �� 5      -   5        $��btnZaposleni��5      $��	Zaposleni��6)   #��[  6=   $
��Left=�6^   $��30��6y   $	��Top=�6�   $��75��6�   6�   �� 5      -   5        $��btnKlijenti��5      $��Klijenti��6(   #��[  6;   $
��Left=�6\   $��30��6w   $	��Top=�6�   $��75��6�   6�   �� 5       -   5        $��btnOsiguranje��5       $��
Osiguranje��6*   #��[  6?   $
��Left=�6`   $��30��6{   $	��Top=�6�   $��75��6�   6�   �� 5!      -   5        $��btnVrsta��5!      $��Vrsta��6%   #��[  65   $
��Left=�6V   $��30��6q   $	��Top=�6}   $��75��6�   6�   �� 5"      -   5        $��btnDestinacija��5"      $��Destinacija��6+   #��[  6A   $
��Left=�6b   $��30��6}   $	��Top=�6�   $��75��6�   6�   �� 5#      -	   5        $��btnPlacanje��5#      $��	Plaćanje��6(   #��[  6;   $
��Left=�6\   $��30��6w   $	��Top=�6�   $��75��6�   6�   5%      �� 5'   
   $��Center=�6   $��30��62   $��Bottom=�6?   $	��360��6Z   $ 
Horizontal=�6f   .+�5(      �� -
   5         ��Name$ btnDodaj��5(      $��Dodaj��6'   $	��107��67   #��[  6C   6d   �� 5)      -   5        $ 	btnIzmeni��5)      $��Izmjeni��6(   $	��108��6:   #��[  6G   6h   �� 5*      -   5        $ 	btnObrisi��5*      $��Obriši��6(   $	��103��69   #��[  6F   6g   5,      5-      5.      