   M S B A M L   `   `   `  ����  Tehtävä13%    LiigaJoukkueSovellus.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Liiga Joukkue Sovellus��5   	   $	��350��6(   $	��500��65   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� $��Joukkueen nimi:��6   $��Center=�6/   �� 5      -   5         ��Name$ JoukkueenNimiTextBox��5      $	��150��64   $��5q�6@   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��10q�6;   .+�5      �� $��Kotikaupunki:��6   $��Center=�6-   �� 5      -   5        $ KotikaupunkiTextBox��5      $	��150��63   $��5q�6?   5      �� 5   
   $��2��6   $ 
Horizontal=�6"   $��10q�6;   .+�5      �� -   5        $��Lisää pelaaja��5      6-   �� 5      -   5        $��Poista pelaaja��5      $��10,0,0,0q�6P   �� 5      -   5        $��Näytä pelaajat��5      $��10,0,0,0q�6P   5      �� 5   
   -   5         ��Name$ PelaajaListBox��5      $��3��6*   $��10q�67   5      5      