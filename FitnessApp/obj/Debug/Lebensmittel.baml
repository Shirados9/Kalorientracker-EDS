   M S B A M L   `   `   `  ����E  AFitnessApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:FitnessApp
FitnessApp  5          FitnessApp.Lebensmittel   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:FitnessApp     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ���#5C99D6
�������$��Verdana)�5   6     � 	Resources  5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Padding �� TextAlignment��%�  '��       �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $��0,0,0,1q�6!   
���������6O   Z� ._�5      �� $ ContentHeader��6(   $��Verdana)�6?   $
��Bold"�6T   $��17(�6f   ���#5C99D6#��z��6�   $ 5,5,5,0q�6�   #��z��6�   $ Justify=�6�   5      5      5      �� 5       �@�OverridesDefaultStyle . 66   �� 5       � ��
 �����6+   5      5      .��5      �� .+�5   
   �� -   5        $��Lebensmitteltabelle��5      $��10q�6   $	��650��6:    �� View 5      �� 5       .P�5!      �� $
��Name��6%   	 �� Width$		 160��63   
 �� CellTemplate
 5"      �� 5#      .R�5$   "   �� $��-9 0 0 0q�6,   $��Center=�6T   $
��Bold"�6o   ���	#FF2196F3��6>   �� *Name+6�   5%      5'      �� 5(      $��Kalorien��6%   $		 160��67   
 5)      �� 5*      .R�5+   "   �� ���	#FF2196F3��6,   �� *
Calories+6F   5,      5.      �� 5/      $��Kohlenhydrate��6%   $		 160��6<   
 50      �� 51      .R�52   "   �� ���	#FF2196F3��6,   �� *Carbs+6C   53      55      �� 56      $
��Fett��6%   $		 160��63   
 57      �� 58      .R�59   "   �� ���	#FF2196F3��6,   �� *Fats+6B   5:      5<      �� 5=      $��Protein��6%   $		 160��66   
 5>      �� 5?      .R�5@   "   �� ���	#FF2196F3��6,   �� *	Protein+6E   5A      5C      �� 5D      $��Löschen��6%   $		 160��66   
 5E      �� 5F      .R�5G   "   �� -   5        
������ $��0q�5G   h   ���	#FF2196F3
 J� Uid 6;   �� *Uid+.��5H   &   �� .+�5I   *   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ TrashCan=�6B   $��15��6R   $��15��6^   5J   '   5K   #   5L      5N      5O      5Q      � 5S   
   $��0 5 10 0q�6    � ColumnDefinitions 5T      �� 5U      $��* �6#   �� 5V      $��* �6#   �� 5W      $��* �6#   �� 5X      $��* �6#   �� 5Y      $��* �6#   �� 5Z      $
��2.3* �6#   .+�5\      �� -   5         ��Name$ NameBox��5\      $��0��6'   $	��Top=�67   $��Center=�6O   $	��110��6l   ���#2196F36x   �� 5]      -   5        $ CaloriesBox��5]      $��1��6+   $	��Top=�6;   $��Center=�6S   $	��110��6�   ���#2196F36�   �� 5^      -   5        $ 
ProteinBox��5^      $��2��6*   $	��Top=�6:   $��Center=�6R   $	��120��6�   ���#2196F36�   �� 5_      -   5        $ CarbsBox��5_      $��3��6(   $	��Top=�68   $��Center=�6P   $	��120��6�   ���#2196F36�   �� 5`      -   5        $ FatBox��5`      $��4��6'   $	��Top=�67   $��Center=�6O   $	��120��6�   ���#2196F36�   �� 5a      -   5         ��Name$ 
AddGrocery��5a   R   $��1��6   $��	Eintragen��6"   $��5��66   $	��200��6F   6f   5b      � 5c   
   .+�5d      �� -	   5        $ EntrySuccessful��5d   %   $��0��6   
��� � �$��15(�6Q   $��Center=�6_   $
��0 10q�6|   �� 5e      -
   5        $ EntryNotSuccessful��5e   %   $��0��6   
���  ��$��15(�6R   $��Center=�6`   $
��0 10q�6}   5f      5g      5h      