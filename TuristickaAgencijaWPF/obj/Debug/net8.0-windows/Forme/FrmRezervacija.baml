   M S B A M L   `   `   `  ����P  LTuristickaAgencijaWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TuristickaAgencijaWPF.FormeTuristickaAgencijaWPF.Forme  5   	   0    *TuristickaAgencijaWPF.Forme.FrmRezervacija   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:TuristickaAgencijaWPF.Forme     5   	     � Title$  Rezervacija��5   	   $	��300��6   $	��400��6*   
������� � 	Resources 5	         Buttons �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%  &	        �� 5
   
   " ��6    .�5      ��  � ��
 ���� 6B   �� 5       � ��$ 14(�6)   66   �� 5       � ��$ 0q�60   6<    5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � ��
 �� ��63   5      5      5      .��5      � .+�5   
   �� $��Naziv Hotela: ��6   $
��Left=�6)   $��	30,20,0,0q�6D   $	��Top=�6W   �� 5   
   $��Popunjeno: ��6   $
��Left=�6&   $��30, 50, 0, 0q�6A   $	��Top=�6W   �� 5   
   $��Zaposleni: ��6   $
��Left=�6&   $��30, 80, 0, 0q�6A   $	��Top=�6W   �� 5   
   $��Putovanje: ��6   $
��Left=�6&   $��30, 110, 0, 0 q�6A   $	��Top=�6Y   �� 5   
   -   5        $��txtNazivHotela��5      $
��Left=�6(   $��
130,25,0,0q�6D    �� TextWrapping$
 Wrap=�6X   $�� ��6l   $	��Top=�6u   $	��120��6�   �� 5   
   -   5        $��cbxPopunjeno��5      $�� ��6'   $
��Left=�63   $��
130,55,0,0q�6O   $	��Top=�6c   �� 5   
   -   5        $��cbZaposleni��5      $
��Left=�6&   $	��Top=�6A   $��130, 85, 0, 0q�6Y   $	��120��6p   	 �� DisplayMemberPath$	 	Zaposleni��6|   
 �� SelectedValuePath$
 zaposleniID��6�   �� 5   
   -   5        $��cbPutovanje��5      $
��Left=�6&   $	��Top=�6A   $��130, 115, 0, 0q�6Y   $	��120��6q   $	 	Aranžman��6}   $
 putovanjeID��6�   �� 5    
   -   5        $��
btnSacuvaj��5       #��[  6#   $��Sačuvaj��6D   $
��Left=�6V   $��
30,200,0,0q�6q   $	��Top=�6�   $��75��6�   6�   �� 5!   
   -   5        $��	btnOtkazi��5!      #��[  6"   $��Otkaži��6C   $
��Left=�6T   $��300,200,0,0q�6o   $	��Top=�6�   $��75��6�   6�   5"      5#      