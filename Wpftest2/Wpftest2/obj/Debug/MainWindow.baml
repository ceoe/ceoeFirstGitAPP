   M S B A M L   `   `   `  ����  Wpftest2    Wpftest2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5   	   c _Microsoft.Expression.Effects, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35?ee4http://schemas.microsoft.com/expression/2010/effects   6N     � Title$  
MainWindow��5      $	��350��6   $	��525��6%   
���   � � Triggers 5      :� 5   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .��5	      � $��26,10,18,10q�6   '  !System.Windows.VisualStateManager   VisualStateGroups 5
   
   %  System.Windows.VisualStateGroup  5      -   5        VisualStateGroup��   Transitions 5      %  System.Windows.VisualTransition  5         GeneratedDuration$ 0:0:1D�6'   H  BMicrosoft.Expression.Interactivity.Core.ExtendedVisualStateManager   TransitionEffect 5      E  ?Microsoft.Expression.Media.Effects.CircleRevealTransitionEffect  5         FeatherAmount$	 0.3Q�6>      Reverse . 6R   5        5      	   From$	 VisualState��6'   $ 0:0:1D�6:    5      C  =Microsoft.Expression.Media.Effects.RadialBlurTransitionEffect  5      5      
   States.
 5         System.Windows.VisualState  -   5        VisualState��5      5       � ColumnDefinitions 5   
   �� 5      $
��116* �6   �� 5      $
��401* �6      CustomVisualStateManager 5   
     5       .+�5"   
   �� -   5         ��Name$
 btn1��5"      $��OK��6   $
��Left=�6,   $��299,258,0,0q�6G   $	��Top=�6\   $��75��6t    J� RenderTransformOrigin$ 0.48,0.5&�6   $��1��6�   A� 5#   
   -   5         A�Name$ Ellipse1��5#      $
��Left=�6$   $	��191��6?   $��	29,48,0,0q�6L   
���   �$	��Top=�6n   $	��191��6�   $��1��6�   $ 0.5,0.5&�6�   ��5$      
� 5%      -   5        RaGradBrush1�� 
� GradientOrigin$ 	0.25,0.25&�5%   <    �� 	Transform 5&      V� 5'      .~�5(      �� �� 5)      �� 5*      T� 5+      5,      .��5.      �  � Color$ 	#FFDE6520��6#    � Offset$ 0.962Q�65   � 5/      $ White��6#   $ 0.035Q�61   � 50      $ 	#FFEBA279��6#   $
 0.75Q�65   51      53      �� 54   
   -   5         ��Name$ TextBox1��54      $��1��6$   $
��Left=�64   $��23��6O   $��247,216,0,0q�6[    �� TextWrapping$
 Wrap=�6p   $	��Top=�6�   $	��120��6�   �� 55   
   -   5        $��test2��55      $��1��6!   $��292,125,10,0q�61   $	��Top=�6G   6_   57      58      