   M S B A M L   `   `   `  ����E  ABeatySalon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BeatySalon.ViewsBeatySalon.Views  5   	   =#clr-namespace:BeatySalon.ViewModelsBeatySalon.ViewModels  5   	   *    $BeatySalon.Views.AuthorizationWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:BeatySalon.Views     5   	   2VM#clr-namespace:BeatySalon.ViewModels     5   	   -   5        $��
AuthWindow��5
   	     � Title$  Салон Красоты��5	   	   $	��250��6   $	��600��6,    � 
ResizeMode$ NoResize=�68    
  WinAll#��[  5
       � DataContext 5      +  %BeatySalon.ViewModels.AuthorizationVM  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5       � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��0.3* �6   �� 5      .+�5   
   ��   Header2#��[ 6   $��Center=�61   $��Center=�6N   $E��?Добро пождаловать в салон красоты.��6i   �� 5   
   $��2��6   $��25q�6   $��
Войти��6*   ��6:   �� *LetsIn+��6U   ��  �� ElementName$ 
AuthWindow���� 5   
   $��1��6   $��1��6   $��	25,0,25,0q�6/     placeHolder#��[ 6\   
 � Tag$ Секретик...��6�   ��6B   �� *
Password+6�   5      5       