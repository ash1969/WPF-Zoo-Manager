   M S B A M L   `   `   `  ����I  EWPF ZooManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPF_ZooManagerWPF_ZooManager  5   	       WPF_ZooManager.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WPF_ZooManager     5   	     � Title$  Zoo Manager Beta��5   	   $	��450��6"   $	��600��6/   .��5	      � .+�5
   
   �� $��Zoo List��6   $
��Left=�6#   $��	10,10,0,0q�6>   $	��Top=�6Q   $��59��6i   $��31��6t   �� 5   
   -   5        $��listZoos��5      $
��Left=�6"   $	��175��6=   $��	10,41,0,0q�6J   $	��Top=�6]   $	��158��6u    J� RenderTransformOrigin$ 
0.62,1.035&�6�   6�   �� 5   
   $��Associated Animals List��6   $
��Left=�62   $��
219,10,0,0q�6M   $	��Top=�6a   $	��221��6y   $��31��6�   �� 5   
   -   5        $��listAssociatedAnimals��5      $
��Left=�6/   $	��175��6J   $��
219,41,0,0q�6W   $	��Top=�6k   $	��158��6�   $ 
0.62,1.035&�6�   �� 5   
   -   5        $��listAllAnimals��5      $
��Left=�6(   $	��302��6C   $��
415,41,0,0q�6P   $	��Top=�6d   $	��158��6|   $ 
0.62,1.035&�6�   6�   �� 5   
   -   5        $��
Delete Zoo��5      $
��Left=�6&   $��
10,234,0,0q�6A   $	��Top=�6U   $	��158��6m   $��29��6y   6�   �� 5   
   $��Remove Animal��6   $
��Left=�6)   $��219,234,0,0q�6D   $	��Top=�6Y   $	��158��6q   $��29��6}   �� 5   
   -   5        $��Add Zoo��5   &   $
��Left=�68   $��
10,314,0,0q�6S   $	��Top=�6g   $	��158��6   $��29��6�   �� 5   
   -   5        $��
Add Animal��5   )   $
��Left=�6>   $��219,314,0,0q�6Y   $	��Top=�6n   $	��158��6�   $��29��6�   �� 5   
   -   5        $��
Update Zoo��5   )   $
��Left=�6>   $��
10,348,0,0q�6Y   $	��Top=�6m   $	��158��6�   $��29��6�   �� 5   
   -   5        $��Update Animal��5   ,   $
��Left=�6D   $��219,348,0,0q�6_   $	��Top=�6t   $	��158��6�   $��29��6�   �� 5   
   -	   5        $��Add Animal To Zoo��5   .   $
��Left=�6J   $��
415,10,0,0q�6e   $	��Top=�6y   $	��158��6�   $��29��6�   �� 5   
   -
   5        $��Delete Animal��5   ,   $
��Left=�6D   $��415,348,0,0q�6_   $	��Top=�6t   $	��158��6�   $��29��6�   �� 5   
   -   5        $��	myTextBox��5      $
��Left=�6#   $��41��6>   $��
10,268,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $��TextBox��6r   $	��Top=�6�   $	��367��6�   5      5      