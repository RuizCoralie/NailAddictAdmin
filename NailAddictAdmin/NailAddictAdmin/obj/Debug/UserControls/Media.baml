   M S B A M L   `   `   `  ����J  FNailAddictAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:NailAddictAdmin.ConvertersNailAddictAdmin.Converters  5      (    "NailAddictAdmin.UserControls.Media   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >	converter(clr-namespace:NailAddictAdmin.Converters     5        � DataContext  5	      ��  �� RelativeSource �� *Self+ � 	Resources 5
      8   2NailAddictAdmin.Converters.InverseBooleanConverter   BooleanToNegate  ButtonStyle �� 
TargetType �� Property �� Value  TextBlockStyleTitre # Body_Content_DataGrid_Centering*  $System.Windows.Controls.DataGridCell �� 
TargetType��%  &	        &	      &	 )    &	       5   
   6,   �� 5   
   " ��6$   .�5      ��  � ��
 �   �6+   �� 5       � ��$ 15(�6)   �� 5       � ��$ Segoe UI)�6+   �� 5       �@J�SnapsToDevicePixels . 64   �� 5       � ��$ 30��6'   �� 5       � ��$ 10q�6'   5      �� 5   
   " ��6,   .�5      ��  � ��$ Segoe Light UI)�6+   �� 5       � ��$ 17(�6)   �� 5       � �� �#BF1E4B6+   �� 5       � ��$ 0,18,0,0q�6'   �� 5       � ��$ Center=�64   5      �� 5   
   "  5   	   .�5      ��  � �� 5      �� 5      "  6&   .R�5       � #��z��6   .+�5!      �� $��Center=�6/   5"      5#      5%      5&      5'      .��5(      �  � RowDefinitions 5)   
   �� 5*      $��50 �6   �� 5+      �� 5,      $��50 �6   .+�5.   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5/      �� $��/Resources/nail.png��6   $��43��61   $��10,0,0,0q�6=   	 J� RenderTransformOrigin$	 
0.494,0.65&�6O   6t   �� 50      $��	Medias : ��6   #��[ 6)   �� 51      -   5        
 ��Name$
 tbAction��51      #��[ 6B   ��6*   �� *Action+6B   52      &   System.Windows.Controls.DataGrid  53   
   -   5           AutoGenerateColumns .  $��1��53   d      CanUserAddRows .     SelectionMode$ Single=�54   :      	CellStyle# [ 55         SelectionUnit$ FullRow=�6P   ��53      �� *MediaCollection+ �� Mode$ TwoWay=� �� SelectedItem 54      �� *MediaSelected+   Columns 56      4  .System.Windows.Controls.DataGridTemplateColumn  57      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    CellTemplate 58      �� 59      .R�5:      �� $��55��6A   $��55��6L   ��6$   �� *	LienMedia+6L   5;      5=      0  *System.Windows.Controls.DataGridTextColumn  5>         Header$ Id��6%    . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5?      $
 Type��6%    .  63   �� *Type+6L     5@      $ Description��6%    .  6:   �� *Description+6Z     5A      $ 
Lien media��6%    .  69   �� *	LienMedia+6W     5B      $ Valide��6%    .  65   �� *Valide+6P   5D      �� 5F   
   $ 
Horizontal=�6   $��2��6.   $��Center=�6;   .+�5G      �� -   5         ��Name$ 
btn_Valide��5G      #��[ 6)   $��Valider��6N   {�6`   �� *VisibilityValide+6�   �� 5H      -   5        $ btn_Supp��5H      #��[ 6'   $��	Supprimer��6L   {�6`   �� *VisibilityValide+ �� 	Converter# [  6�   5I      5J      5K      