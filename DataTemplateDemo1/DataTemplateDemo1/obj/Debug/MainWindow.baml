   M S B A M L   `   `   `  ����L  HDataTemplateDemo1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:DataTemplateDemo1DataTemplateDemo1  5   	   "    DataTemplateDemo1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:DataTemplateDemo1     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F     � Title$  DataTemplateDemo��5   	   $	��680��6"   $
��1167��6/    � 	Resources 5      2   ,DataTemplateDemo1.AutoMakerTologoPathConvert   A2L.   (DataTemplateDemo1.NameToPhotoPathConvert  N2P6   0DataTemplateDemo1.SelectedItemToPhotoPathConvert 	 SII2P  CarDetailViewTemplate �� CornerRadius ��Name �� StretchDirection �� 	Converter �� Orientation  CarListViewTemplate��%�  &	        &	      &	 &     &	 9     7  &	 �    7     5	   
   6+     5
   
   6'     5   
   6/   �� 5   
   .R�5      �� 
���   �$��1q�6)   $ 15��6>   #��� ��6P   ._�5      �� $��5q�6   .+�5      �� $ 
imagePhoto��66   $	��560��6   $	��920��6)   $��UniformToFill=�6�   $
 Both=�6�   $��10q�6�   ��6K   �� *Name+8   5      �� 5      $ 
Horizontal=�6!   $	��5,0q�6:   .+�5      �� $��Name:��6$   $
��Bold"�61   $��20(�6C   �� 5      $��20(�6:   $	��5,0q�6H   ��6$   �� *Name+6H   5      �� 5      $ 
Horizontal=�6!   $	��5,0q�6:   .+�5      �� $��
AutoMaker:��6$   $
��Bold"�66   �� 5      $	��5,0q�6@   ��6$   �� *	AutoMaker+6@   �� 5      $��Year:��6$   $
��Bold"�61   �� 5      $	��5,0q�6;   ��6$   �� *Year+6;   �� 5      $��
Top Speed:��6$   $
��Bold"�66   �� 5      $	��5,0q�6?   ��6$   �� *
TopSpeed+6?   5       5!      5"      5#      �� 5&   
   .R�5(      � $��2q�6   .+�5)      �� $ 
Horizontal=�6   .+�5*      �� $ imglogo��6   $��3��6-   $��50��6?   $��50��6J   $��UniformToFill=�6V   ��6n   �� *	AutoMaker+8   �� 5,      $	��5,0q�6!   .+�5-      �� $��16(�6;   $
��Bold"�6I   ��6%   �� *Name+6I   �� 5.      $��14(�6;   ��6%   �� *Year+6;   5/      50      51      52      53      .��56      �� -   5         ��Name$ 	AllCanvas��56       J� Opacity$	 0.9Q�6    ��57   
   �� 58      -   5        testImageBrush��	 �� ImageSource	 58   2   �� *SelectedItem+
 �� ElementName$
 listBoxCars��# [ .+�5;   
   �� -   5         ��Name$ StackPanel1��5;      $ 
Horizontal=�6+   .+�5<      >� -   5         >�Name$ userControl��5<      #��[ 6/   ��6h   �� *SelectedItem+$
 listBoxCars���� 5=      -   5         ��Name$ listBoxCars��5=      $	��180��6+   $��10q�67   #��[ 6C   $	��500��6w   $	��Top=�6�   5?      5@      5A      