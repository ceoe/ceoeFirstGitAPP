   M S B A M L   `   `   `  ����O  KControlTemplateDemo1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ControlTemplateDemo1ControlTemplateDemo1  5   	   %    ControlTemplateDemo1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4local"clr-namespace:ControlTemplateDemo1     5   	     � Title$  ControlTemplateDemo��5   	   $	��350��6%   $	��525��62   #��� ��6>    � 	Resources 5         	TileBrush j� TileMode j� Viewport j� ViewportUnits �� ImageSource �� Opacity��%w   &	        �� 5   
   $
 Tile=�6'   $ 	0 0 64 64�67   $ Absolute=�6L   $ bentley.jpg��6e   $	 0.9Q�6   5	      .��5      � $��
0,0,-8,-20q�6   .+�5   
   �� $	��Top=�6   $��80��6)   }�. $��0,0,0,0q�6J   .+�5      �� -   5        $��content1��5      $��Center=�6)   $��Center=�6F   z�5      T� 5       T� Y$ 0Q�6)   .+�5      �� $��36(�6   
��� ���$ ��#####移动的文字$$$$$$��6>   5       � Triggers 5      :� 5      	 :� RoutedEvent$	 local:MainWindow.Loaded��6    .[�5      �� .��5      �� .��5      W� 
 W� From$	
 350X�6.   	 W� To$
 -450X�69    g� Duration$ 0:0:10D�6C    g� RepeatBehavior$ Forever��5   )    �� 
TargetName$ content1��5   )    �� TargetProperty$ RenderTransform.X�5   )   5      5      5      5      �� 5!   
   -   5        $��Start Timer��5!      $
��Left=�6'   $��
30,104,0,0q�6B   $	��Top=�6V   $	��110��6n   $��31��6z     RoundCornerButtonStyle#���  6�   6�   � 5"   
   $
��Left=�6   $��38��62   $��
30,207,0,0q�6>   $	��Top=�6R   $	��133��6j    J� RenderTransformOrigin$ 0.615,1.237&�6v     MYProgressBarStyle#���  6�    � Value 6�   �� *Value+ �� ElementName$ slider�� �� Mode$ TwoWay=��� 5#   
   -   5         ��Name$ slider��5#      $
��Left=�6!   $��
30,270,0,0q�6<   $	��Top=�6P   $	��245��6h    � Maximum$	 100Q�6t   �� 5$   
   -   5        $��
Stop Timer��5$      $
��Left=�6&   $��
30,156,0,0q�6A   $	��Top=�6U   $	��110��6m   $��29��6y   6�   �� 5%   
   -   5         ��Name$	 tb3��5%      $
��Left=�6   $��30��6:   $��	30,50,0,0q�6F    �� TextWrapping$
 Wrap=�6Y   $	��Top=�6m   $	��228��6�   $ 0.574,1.067&�6�   �� 5&   
   -   5        $	 tb2��5&      $
��Left=�6   $��28��6:   $��
280,52,0,0q�6F   $
 Wrap=�6Z   $��TextBox��6n   $	��Top=�6}   $	��175��6�     TextBoxStyle1#���  6�   �� 5(   
   $��280,104,35,35q�6   .+�5)      �� $	��200��6   $��70��6!   #��[  60   $��5q�6d   $��Black"�6p   $��22(�6�   $��5q�6�   $��A Tile Button��6�   $	��196��6�   $ 0.5,0.5&�6�   ���	#FFF1E7116�   �� 5*      -   5        $��A Normal Button��5*      $��41��6/   $��20(�6;   6I   �� 5+      -   5         ��Name$ btntestbrush��5+      $	��200��6+   $��70��67   #���   6F   $��5q�6{   $��Black"�6�   $��22(�6�   $��5q�6�   $��A Tile Button��6�   $	��196��6�   $ 0.5,0.5&�6�   ���	#FFF1E711 5,      ��%x   &	        �� 5-      $
 Tile=�64   $ Absolute=�6E   $ 	0 0 48 48�6^   $ bmw.jpg��6s   $	 0.6Q�6�   6�   5.      5/      51      54      55      