   M S B A M L   `   `   `  ����P  LTuristickaAgencijaWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TuristickaAgencijaWPF.FormeTuristickaAgencijaWPF.Forme  5   	   .    (TuristickaAgencijaWPF.Forme.FrmPutovanje   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:TuristickaAgencijaWPF.Forme     5   	     � Title$  	Putovanje��5   	   $	��350��6   $	��400��6(   
������� � 	Resources 5	         Buttons �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%  &	        �� 5
   
   " ��6    .�5      ��  � ��
 ���� 6B   �� 5       � ��$ 14(�6)   66   �� 5       � ��$ 0q�60   6<    5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � ��
 �� ��63   5      5      5      .��5      � .+�5   
   �� $��Broj dana: ��6   $
��Left=�6&   $��	30,20,0,0q�6A   $	��Top=�6T   �� 5   
   $��Cijena: ��6   $
��Left=�6#   $��	30,50,0,0q�6>   $	��Top=�6Q   �� 5   
   $��Datum: ��6   $
��Left=�6"   $��	30,80,0,0q�6=   $	��Top=�6P   �� 5   
   $��Vrsta: ��6   $
��Left=�6"   $��
30,110,0,0q�6=   $	��Top=�6Q   �� 5   
   $��Destinacija: ��6   $
��Left=�6(   $��
30,140,0,0q�6C   $	��Top=�6W   �� 5   
   $��	Klijent: ��6   $
��Left=�6$   $��
30,170,0,0q�6?   $	��Top=�6S   �� 5   
   -   5        $��txtBrojDana��5      $
��Left=�6%   $	��Top=�6@   $��
130,25,0,0q�6Y    �� TextWrapping$
 Wrap=�6m   $�� ��6�   $	��120��6�   �� 5   
   -   5        $��	txtCijena��5      $
��Left=�6#   $��
130,55,0,0q�6?   $	��Top=�6S   $
 Wrap=�6k   $�� ��6   $	��120��6�   (  "System.Windows.Controls.DatePicker  5    
   -   5        $��dpDatum��5       $
��Left=�6$   $��
130,82,0,0q�6?   $	��Top=�6T   �� 5!   
   -   5        $��cbVrsta��5!      $
��Left=�6"   $	��Top=�6=   $��130,115,0,0q�6U   $	��120��6j   	 �� SelectedValuePath$	 vrstaID��6w   
 �� DisplayMemberPath$
 
nazivVrste��6�   �� 5"   
   -   5        $��cbDestinacija��5"      $
��Left=�6(   $	��Top=�6C   $��130, 145, 0, 0q�6[   $	��120��6t   $	 destinacijaID��6�   $
 Destinacija��6�   �� 5#   
   -   5        $��	cbKlijent��5#      $
��Left=�6$   $	��Top=�6?   $��130, 175, 0, 0q�6W   $	��120��6p   $	 	klijentID��6|   $
 Klijent��6�   �� 5$   
   -   5        $��
btnSacuvaj��5$      #��[  6#   $��Sačuvaj��6D   $
��Left=�6V   $��
30,240,0,0q�6q   $	��Top=�6�   $��75��6�   6�   �� 5%   
   -   5        $��	btnOtkazi��5%      #��[  6"   $��Otkaži��6C   $
��Left=�6T   $��300,240,0,0q�6o   $	��Top=�6�   $��75��6�   6�   5&      5'      