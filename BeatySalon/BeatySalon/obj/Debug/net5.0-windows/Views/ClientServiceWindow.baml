   M S B A M L   `   `   `  ����E  ABeatySalon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BeatySalon.ViewsBeatySalon.Views  5   	   =#clr-namespace:BeatySalon.ViewModelsBeatySalon.ViewModels  5   	   *    $BeatySalon.Views.ClientServiceWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:BeatySalon.Views     5   	   2VM#clr-namespace:BeatySalon.ViewModels     5   	     � Title$'  !Добавление заявки��5	   	   $	��500��6#   $	��400��60    � 
ResizeMode$ NoResize=�6<    
  WinAll#��[  6R   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Center=�6   $��2��6-   $%��Выбранная услуга��6>     Header3#��[ 6Y   �� 5   
   $��Italic$�6   $��1��6'   $��Center=�67   �� 5      �6   �� *SelectedService.Title+5      �� 5    
   $��Italic$�6   $��Center=�6'   $��1��6D   $��1��6T   �� 5!      �6   �� *#!SelectedService.DurationInSeconds+  SecondsToMinuteConvert �� 	Converter# [  �� 5"      $�минут.��6   5#      �� 5%   
   $��Center=�6   $��2��6-   $��Клиент��6:   #��[ 6K   �� 5'   
   $��25q�6   $��2��6   $��1��6,   ��6<   �� *	Clients+ �� SelectedItem 6\   �� *ClientService.Client+��5(      �� 5)      .R�5*      �� .+�5+      �� ��6$   �� *	FirstName+�� 5,      ��6$   �� *
LastName+�� 5-      ��6$   �� *
Patronymic+5.      5/      51      �� 53   
   $��Center=�6   $��4��6-   $��
Часов��6:   #��[ 6J   �� 54   
   $��Center=�6   $��4��6-   $��1��6:   $��
Минут��6J   #��[ 6Z   (  "System.Windows.Controls.DatePicker  55   
   $��25q�6   $��3��6!   $��2��6.      SelectedDate 6B   �� *Date+�� 56   
   $��Center=�6   $��30��6/   $	��150��6;   $��5��6G   ��6T   �� *Hours+�� 57   
   $��Center=�6   $��30��6/   $	��150��6;   $��5��6H   $��1��6U   ��6e   �� *	Minutes+�� 58   
   $��6��6   $��2��6   $��20q�62   $��Сохранить��6>   ��6R   �� *AddClientService+��6w   ��  �� RelativeSource ��  �� AncestorType
 Window59      5:      