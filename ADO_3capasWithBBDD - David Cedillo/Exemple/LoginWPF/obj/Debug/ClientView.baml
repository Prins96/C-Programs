   M S B A M L   `   `   `  ����C  ?LoginWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:LoginWPFLoginWPF  5   	       LoginWPF.ClientView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:LoginWPF     5   	   -   5          � Title$  
ClientView��5   	   $	��486��6   $	��800��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K   ��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 
DodgerBlue��6    � Offset$ 0Q�6.   � 5      $ Silver��6   $ 1Q�6*   5      .��5      � .+�5   
   o� $��30��6   $	��Top=�6   
���   �.@�5      m� $��	_Clientes��6   $��15(�6*   
�������.@�5      m� -   5        $��_Listar��5      
���   � m� InputGestureText$ Ctrl + L��6?   6[   5      m� 5      $��_Orders��6   $��15(�6(   
�������.@�5      m� -   5        $��L_istado��5      
���   �$ Ctrl + I��6@   6\   5      5      �� 5   
   -   5         ��Name$ lbWhoIs��5      $��HOlaaaa��6!   $��Verdana)�63   ���	#00000000���	#FFFFFFFF$
��Bold"�6v   $��100, 40, 100, 350q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        	  Name$	 dataGridClients��5      
   GridLinesVisibility$
 Vertical=�6W      RowBackground
 �����   AlternatingRowBackground
 ��ح�
���/���$��2q�6�   "   VerticalScrollBarVisibility$ Visible=�6�      CanUserResizeRows .     CanUserResizeColumns .     HeadersVisibility$	 All=�6B  $��98,109,98,46q�6Z     
IsReadOnly . 6p  �� 5   
   -   5         ��Name$ 	myListBox��5      $��120,150,120,80q�6&   ��5      �� 5      .R�5      �  � ColumnDefinitions 5       �� 5!      $��50 �6/   �� 5"      $	��100 �6/   .+�5$      �� $��0��6$   ��64   �� *	IdOrder+�� 5%      $��1��6$   ��64   �� *
ClientName+5&      5'      5)      �� 5+   
   -   5         ��Name$ myListView2��5+      $��98,109,98,60q�6(   $��Center=�6>    �� View 5,      �� 5-      .P�5.      �� $��
ID Article��6%    �� Width$	 150��69    �� CellTemplate 5/      �� 50      .R�51   "   �� $��Center=�6G   ��6,   �� *	IdArticle+6G   52      54      �� 55      $��Article Name��6%   $	 150��6;    56      �� 57      .R�58   "   �� $��Center=�6I   ��6,   �� *ArticleName+6I   59      5;      �� 5<      $��
Unit Price��6%   $	 150��69    5=      �� 5>      .R�5?   "   �� $��Center=�6G   ��6,   �� *	UnitPrice+6G   5@      5B      �� 5C      $��Availability��6%   $	 150��6;    5D      �� 5E      .R�5F   "   �� $��Center=�6J   ��6,   �� *Availability+6J   5G      5I      5J      5L      �� 5N   
   -   5         ��Name$ 
BtExportar��5N      $��Exportar a PDF��6%   $��Center=�6X   $��	0,410,0,0q�6u   $��31��6�   $��94��6�   ��5O      �� 5P       �� 
TargetType" ��6"   .R�5Q      �� #��z��6   
���   �$��1q�6[    �� CornerRadius$ 5��6o   ._�5R      �� $��Center=�6+   $��Center=�6H   5S      5T      ��5V      �� 5W       �� 
TargetType" ��6   .�5X      ��  �� Property � �� �� Value
 ��ح�63   �� 5Y       � ��
 �   �63   �� 5Z       � ��$
 Bold"�63   �� 5[       � ��$ 10q�60    �� Triggers 5\      P� 5]       P� Property �@J�IsMouseOver  P� Value  . . �5^      ��  � ��
 ����6;   5_      P� 5`       � ��  . . �5a      ��  � ��
 ��� �6;   5b      5d      5f      5g      5h      