   M S B A M L   `   `   `  ����P  LTuristickaAgencijaWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TuristickaAgencijaWPF.FormeTuristickaAgencijaWPF.Forme  5   	   /    )TuristickaAgencijaWPF.Forme.FrmOsiguranje   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:TuristickaAgencijaWPF.Forme     5   	     � Title$  
Osiguranje��5   	   $	��300��6   $	��400��6)   
������� � 	Resources 5	         Buttons �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%  &	        �� 5
   
   " ��6    .�5      ��  � ��
 ���� 6B   �� 5       � ��$ 14(�6)   66   �� 5       � ��$ 0q�60   6<    5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � ��
 �� ��63   5      5      5      .��5      � .+�5   
   �� $��Broj pasoša: ��6   $	��Top=�6(   $
��Left=�6@   $��	30,20,0,0q�6[   �� 5   
   $��JMBG:��6   $	��Top=�6    $
��Left=�68   $��	30,50,0,0q�6S   �� 5   
   $��Broj polise: ��6   $	��Top=�6(   $
��Left=�6@   $��	30,80,0,0q�6[   �� 5   
   $��	Starost: ��6   $	��Top=�6$   $
��Left=�6<   $��30, 110, 0,0q�6W   �� 5   
   $��	Klijent: ��6   $	��Top=�6$   $
��Left=�6<   $��30, 140, 0, 0q�6W   �� 5   
   -   5        $��txtBrojPasosa��5      $	��Top=�6'   $
��Left=�6?   $��130, 25, 0,0q�6[    �� TextWrapping$
 Wrap=�6q   $�� ��6�   $	��120��6�   �� 5   
   -   5        $��txtJmbg��5      $	��Top=�6!   $
��Left=�69   $��130, 55, 0,0q�6T   $
 Wrap=�6j   $�� ��6~   $	��120��6�   �� 5   
   -   5        $��txtBrojPolise��5      $	��Top=�6'   $
��Left=�6?   $��130, 85, 0,0q�6[   $
 Wrap=�6q   $�� ��6�   $	��120��6�   �� 5    
   -   5        $��
txtStarost��5       $	��Top=�6$   $
��Left=�6<   $��130, 115, 0,0q�6W   $
 Wrap=�6n   $�� ��6�   $	��120��6�   �� 5!   
   -   5        $��	cbKlijent��5!      $	��Top=�6$   $
��Left=�6<   $��130,145, 0,0q�6W   $	��120��6m   	 �� DisplayMemberPath$	 Klijent��6y   
 �� SelectedValuePath$
 	klijentID��6�   �� 5"   
   -   5        $��
btnSacuvaj��5"      #��[  6#   $��Sačuvaj��6D   $	��Top=�6V   $
��Left=�6n   $��
30,180,0,0q�6�   $��30��6�   $��61��6�   6�   �� 5#   
   -   5        $��	btnOtkazi��5#      #��[  6"   $��Otkaži��6C   $	��Top=�6T   $
��Left=�6l   $��300, 180, 0, 0q�6�   $��30��6�   $��61��6�   6�   5$      5%      