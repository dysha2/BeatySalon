   M S B A M L   `   `   `  ����E  ABeatySalon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BeatySalon.ViewsBeatySalon.Views  5   	   =#clr-namespace:BeatySalon.ViewModelsBeatySalon.ViewModels  5   	   !    BeatySalon.Views.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:BeatySalon.Views     5   	   2VM#clr-namespace:BeatySalon.ViewModels     5   	     � Title$  Список услуг��5	   	   $	��600��6   $	��800��6+   $	��400��67   $	��600��6G    
  WinAll#��[  5
   	    � DataContext 5      "   BeatySalon.ViewModels.MainVM  5   
   .��5      ]� .+�5   
   o� $	��Top=�6    � 	Resources 5       �� 
TargetType  VisibleByAdmin �� Property  
FocusColor �� Value  AdditionalBackgr �� Triggers �� Binding �� Value��%;  &	       7  7  �� 5      " m�6   .�5      ��  � ��8   63   �� 5       � ��$ 14(�61   �� 5       � ��$
 Bold"�63   �� 5       � ��8  63    5      �� 5       6&   �� *	IsAdmin+	 false6B   .a�5      ��  � y�$ 	Collapsed=�6;   5      5      5      .@�5      m� $��Фильтрация��6   .@�5       m� $��От 0% до 5%��6   	 m� CommandParameter$	 0��6O   
 m� Command
 60   �� *	SetFilter+6O   m� 5!      $��От 5% до 15%��6   $	 1��6P   
 61   �� *	SetFilter+6P   m� 5"      $��От 15% до 30%��6   $	 2��6Q   
 62   �� *	SetFilter+6Q   m� 5#      $��От 30% до 70%��6   $	 3��6Q   
 62   �� *	SetFilter+6Q   m� 5$      $��От 70% до 100%��6   $	 4��6R   
 63   �� *	SetFilter+6R   m� 5%      $��Все��6   $	 5��6G   
 6(   �� *	SetFilter+6G   5&      m� 5'      $��Сохранить��6   
 6*   �� *SaveChanges+m� 5(      $!��Ближние записи��6   #��[ 6/   
 6W   �� *NearEntries+m� 5)      $#��Добавить услугу��6   #��[ 60   
 6X   �� *
AddService+5*      �� 5+   
   $��12,12,26,12q�6     placeHolder#��[ 6j   
 � Tag$ Найти...��6�   $	��Top=�6�   ��6'   �� *SearchString+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5,   
   $��12,0,0,0q�6   $0��*Сортировка по убыванию��6%   $	��Top=�6F    d� IsThreeState$ False��6[    d� 	IsChecked 6p   �� *
SortMode+�� 5-   
   $��Bottom=�6   �� 5.      $�Элементов��6    �� 5/      �6   ��  �� ElementName$ ServicesListBox�� �� Path$ Items.Count� �� Mode$ OneWay=� �� 50      $
�из��6    �� 51      �6   �� *ServicesCount+$ OneWay=�52      �� 53   
   -   5        $��ServicesListBox��54        ServicesTemplate#��[ 53   3   $��Stretch=�54   )   ��53      �� *
Services+ �� SelectedItem 6d   �� *SelectedService+54   )   55      56      