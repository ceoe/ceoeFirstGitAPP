   M S B A M L   `   `   `  ����a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  5       ControlTemplateDemo1   ControlTemplateDemo1.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ]ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     5      @d2http://schemas.microsoft.com/expression/blend/2008     6\   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�     �� 	Resources  5         TextBoxBorder �� EndPoint � MappingMode �� 
StartPoint � Color � Offset  RoundCornerTextBoxStyle �� 
TargetType �� BasedOn �� Property	 �� Value
 �� 
TargetType ��Name J� SnapsToDevicePixels �� CornerRadius ��Name � ForceCursor J� Opacity J� OpacityMask �� Triggers P� Property P� Value �� 
TargetName �� Triggers ]� 
Conditions �� Property �� Value  ButtonFocusVisual �� StrokeDashArray  ButtonNormalBackground  ButtonNormalBorder �� Color  RoundCornerButtonStyle+   %Microsoft.Windows.Themes.ButtonChrome  Name   BorderBrush   
Background J� IsMouseOver    RenderMouseOver!   RenderPressed" �� IsDefaulted#   RenderDefaulted  ProgressBarBackground  ProgressBarBorderBrush  ProgressBarGlassyHighlight 	 ProgressBarTopHighlight $
  ProgressBarIndicatorAnimatedFill $  ProgressBarIndicatorDarkEdgeLeft % !ProgressBarIndicatorDarkEdgeRight * &ProgressBarIndicatorLightingEffectLeft$ 
� RadiusY% 
� RadiusX& �� RelativeTransform & "ProgressBarIndicatorLightingEffect + 'ProgressBarIndicatorLightingEffectRight ' #ProgressBarIndicatorGlassyHighlight  MYProgressBarStyle' �Name( �� RadiusY) �� RadiusX* ��Name+ {�Name, � ColumnDefinitions- � RowDefinitions. �� Angle  TextBoxStyle1,   &Microsoft.Windows.Themes.ListBoxChrome/  Name0   BorderBrush1   BorderThickness2   
Background3   RenderMouseOver4 J� IsKeyboardFocusWithin5   RenderFocused��%"  &	        &	 �     7   &	 %    &	 �    &	 �    &	 �    7  7  7  &	 �    &	 o    &	     &		 �    &	
 C    &	 ?    &	 	    &	 �    &	 �    &	     &	 �    &	 l    7  7  7  7 	 7 
 7  7  7  7  7  7  7 	 &	 �    7   �� 5   
   $
 0,20&�64   $ Absolute=�6D   $	 0,0&�6[   .��5	      � $ #ABADB3��6   $
 0.05Q�6+   � 5
      $ #E2E3EA��6   $
 0.07Q�6+   � 5      $ #E3E9EF��6   $ 1Q�6+   5      �� 5   
   " ��6C    60   Z� .�5      ��  � ��#	 � ��6+   �� 5       � ��#	 � ��6+   �� 5       � ��8	   6,   �� 5       � ��$	 1q�60   �� 5       � ��$	 1q�6(   �� 5       �@J�	AllowDrop	 . 6*   �� 5       �@�FocusVisualStyle	 61   Z� �� 5       �@��PanningMode$	 VerticalFirst=�69   �� 5       �@��IsFlicksEnabled	 .  67   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5      �� $ Bd��6"    . #��z��6I   #��z��6u   #��z��6�   $ 10��6�   ._�5      �� $ PART_ContentHost��6+   # z 6E   #��� ��6�   ���	#FF75F50B . $	 0.5Q�6�   ��5   "   �� 5   &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5   *   � $ Black��67   $ 0Q�6E   � 5   *   $ 	#FFF10505��67   $ 1Q�6I   5    '    5"   "   �� 5#   &   .��5%   "   �� $	��100��6,   $
��Wrap=�69   $��	TextBlock��6M   $	��100��6^   5&      5'       5(      P� 5)       � {� .  . �5*   "   �� $ Bd��6?   #	 � ��6O    � ���� 5+   "   #	 � ��6?    � ��5,      5.      50       51      ]� 52       53      �� 54      + �@��#IsInactiveSelectionHighlightEnabled . 6S   �� 55       �@��IsSelectionActive .  6A   ./�57      ��  �@��SelectionBrush#	 � /�67   58      5:      �� 5;   
   .�5<      ��  � ��	 5=      �� 5>      .R�5?      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5@      5B      5C      �� 5D   
   $	 0,1&�6=   $	 0,0&�6L   .��5E      � $ #F3F3F3��6   $ 0Q�6+   � 5F      $ #EBEBEB��6   $	 0.5Q�6+   � 5G      $ #DDDDDD��6   $	 0.5Q�6+   � 5H      $ #CDCDCD��6   $ 1Q�6+   5I      �� 5J   
   $ 	#FF707070��65   �� 5K   
   " ��6/   .�5L      ��  �@�FocusVisualStyle8	   61   �� 5M       � ��8	  6+   �� 5N       � ��8	  6,   �� 5O       � ��$	 1q�60   �� 5P       � ��#	 � ��6+   �� 5Q       � ��$	 Center=�6;   �� 5R       � ��$	 Center=�69   �� 5S       � ��$	 1q�6(   �� 5T       � ��	 5U      �� 5V      "
 ��6&   .R�5W        $ Chrome��6.   # z��6>   # z��6j   #  z 6�   #! z��6�   ## z" 6�    . ._�5X      �� #��z��6/   #��z��6r   ��. # z 6�   #��z��6�   $��RightToLeft=�6+  5Y       5Z      P� 5[       �@J�IsKeyboardFocused . . �5\   "   �� $ Chrome��6D    �@ RenderDefaulted	 . 6X   5]      P� 5^       �@d�	IsChecked$
 trueY�6H   . �5_   "   �� $ Chrome��6B    �@ RenderPressed	 . 6V   5`      P� 5a       � {� .  . �5b   "   ��  � ��	 �#ADADAD6?   5c      5e      5g      5h      �� 5i   
   $	 1,0&�6<   $	 0,0&�6K   .��5j      � $ #BABABA��6   $ 0Q�6+   � 5k      $ #C7C7C7��6   $	 0.5Q�6+   � 5l      $ #BABABA��6   $ 1Q�6+   5m      �� 5n   
   $	 0,1&�6=   $	 0,0&�6L   .��5o      � $ #B2B2B2��6   $ 0Q�6+   � 5p      $ #8C8C8C��6   $ 1Q�6+   5q      �� 5r   
   $	 0,1&�6A   $	 0,0&�6P   .��5s      � $ 	#50FFFFFF��6   $ 0.5385Q�6-   � 5t      $ 	#00FFFFFF��6   $ 0.5385Q�6-   5u      �� 5v   
   $	 0,1&�6>   $	 0,0&�6M   .��5w      � $ 	#80FFFFFF��6   $
 0.05Q�6-   � 5x      $ 	#00FFFFFF��6   $
 0.25Q�6-   5y      �� 5z   
   $	 1,0&�6G   $	 0,0&�6V   .��5{      � $ 	#00FFFFFF��6   $ 0Q�6-   � 5|      $ 	#60FFFFFF��6   $	 0.4Q�6-   � 5}      $ 	#60FFFFFF��6   $	 0.6Q�6-   � 5~      $ 	#00FFFFFF��6   $ 1Q�6-   5      �� 5�   
   $	 1,0&�6G   $	 0,0&�6V   .��5�      � $ 	#0C000000��6   $ 0Q�6-   � 5�      $ 	#20000000��6   $	 0.3Q�6-   � 5�      $ 	#00000000��6   $ 1Q�6-   5�      �� 5�   
   $	 1,0&�6H   $	 0,0&�6W   .��5�      � $ 	#00000000��6   $ 0Q�6-   � 5�      $ 	#20000000��6   $	 0.7Q�6-   � 5�      $ 	#0C000000��6   $ 1Q�6-   5�      
� 5�   
   $$ 1Q�6M   $% 1Q�6Y   $& 1,0,0,1,0.5,0.5W�6e   .��5�      � $ 	#60FFFFC4��6   $ 0Q�6-   � 5�      $ 	#00FFFFC4��6   $ 1Q�6-   5�      �� 5�   
   $	 0,0&�6I   $	 0,1&�6X   .��5�      � $ 	#60FFFFC4��6   $ 0Q�6-   � 5�      $ 	#00FFFFC4��6   $ 1Q�6-   5�      
� 5�   
   $$ 1Q�6N   $% 1Q�6Z   $& 1,0,0,1,-0.5,0.5W�6f   .��5�      � $ 	#60FFFFC4��6   $ 0Q�6-   � 5�      $ 	#00FFFFC4��6   $ 1Q�6-   5�      �� 5�   
   $	 0,1&�6J   $	 0,0&�6Y   .��5�      � $ 	#90FFFFFF��6   $ 0.5385Q�6-   � 5�      $ 	#00FFFFFF��6   $ 0.5385Q�6-   5�      �� 5�   
   " �6+   .�5�      ��  � ��	 �#01D3286+   �� 5�       � ��8	   6+   �� 5�       � ��8	  6,   �� 5�       � ��$	 1q�60   �� 5�       � ��	 5�      �� 5�      "
 �6&   .R�5�      � $' TemplateRoot��6    . .+�5�      �� #��z��6(   $( 2��6L   $) 2��6X   �� 5�      8�� $ 2��6^   $��1q�6o   �� 5�      ���	#80FFFFFF$��1,0,1,1q�6=   8�� $��1q�6�   �� 5�      $* 
PART_Track��6(   $��1q�6<   {� 5�      $+ PART_Indicator��6(   $
��Left=�6@   $��1q�6[   ._�5�   "   � $' 
Foreground��6'   .+�5�   &   �� $* 	Indicator��60   #��z��6C   � 5�   &   $' 	Animation��6+   }�. .+�5�   *   �� $* PART_GlowRect��64   8�� $
��Left=�6�   $��
-100,0,0,0q�6�   $	��100��6�   5�   '   � 5�   &   $' Overlay��6+   , 5�   *   �� 5�   .   $��15��6?   �� 5�   .   $
��0.1* �6?   �� 5�   .   $��15��6?   - 5�   *   �� 5�   .   �� 5�   .   .+�5�   *   �� $* LeftDark��64   8�� $��1,1,0,1q�6   $( 1��6�   $) 1��6�   $��2��6�   �� 5�   *   $* 	RightDark��64   $��2��6G   8�� $��0,1,1,1q�6�   $( 1��6�   $) 1��6�   $��2��6�   �� 5�   *   $* 	LeftLight��64   $��0��6G   8�� $��2��6�   �� 5�   *   $* CenterLight��64   $��1��6I   8�� $��2��6�   �� 5�   *   $* 
RightLight��64   $��2��6H   8��	 $��2��6�   �� 5�   *   $ 
Highlight1��61   8��
 $��3��6�   $��2��6�   �� 5�   *   $ 
Highlight2��61   8�� $��3��6{   $��2��6�   5�   '   5�   #   5�      �� 5�      #��z��6%   #��z��6Q   $ 2��6�   5�       5�      P� 5�       �@�Orientation$ Vertical=�6=   . �5�   "   �� $ TemplateRoot��6D    �@�LayoutTransform	 5�   &   �� 5�   *   $	. -90Q�6:   5�   #   5�      P� 5�       �@�IsIndeterminate . . �5�   "   �� $ LeftDark��6?    � y�$	 	Collapsed=�6U   �� 5�   "   $ 	RightDark��6?    � y�$	 	Collapsed=�6V   �� 5�   "   $ 	LeftLight��6?    � y�$	 	Collapsed=�6V   �� 5�   "   $ CenterLight��6?    � y�$	 	Collapsed=�6X   �� 5�   "   $ 
RightLight��6?    � y�$	 	Collapsed=�6W   �� 5�   "   $ 	Indicator��6?    � y�$	 	Collapsed=�6V   5�      P� 5�       �@�IsIndeterminate .  . �5�   "   �� $ 	Animation��6?    � ��	 �	#80B5FFA96V   5�      5�      5�      5�      �� 5�   
   " ��69    6&   Z� .�5�      ��  � ��#	 � ��6+   �� 5�       � ��#	 � ��6+   �� 5�       � ��8	   6,   �� 5�       � ��$	 1q�60   �� 5�       � ��$	 1q�6(   �� 5�       �@J�	AllowDrop	 . 6*   �� 5�       �@�FocusVisualStyle	 61   Z� �� 5�       �@��PanningMode$	 VerticalFirst=�69   �� 5�       �@��IsFlicksEnabled	 .  67   �� 5�       � ��	 5�      �� 5�      "
 ��6&   .R�5�        $/ Bd��6/   #0 z��6;   #1 z��6g   #2 z��6�   #3 z 6�   #5 z4 6�    . ._�5�      �� $ PART_ContentHost��6+   # z 6E   $��	0,-2,-2,0q�6�   $��26��6�   $	��Top=�6�   5�       5�      P� 5�       � {� .  . �5�   "   �� $ Bd��6?   #	 � ��6O    �@ 
Background�� 5�   "   #	 � ��6?    � ��5�      5�      5�       5�      ]� 5�       5�      �� 5�      + �@��#IsInactiveSelectionHighlightEnabled . 6S   �� 5�       �@��IsSelectionActive .  6A   ./�5�      ��  �@��SelectionBrush#	 � /�67   5�      5�      5�      5      