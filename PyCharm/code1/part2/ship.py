import  pygame
class Ship:

    def __init__(self,ai_game):

        self.moving_right = False
        self.moving_left = False
        self.screen=ai_game.screen
        self.settings=ai_game.settings
        self.screen_rect=ai_game.screen.get_rect()

        #加载飞船图像并获取其外部矩形。
        self.image=pygame.image.load('images/ship.bmp')
        self.rect=self.image.get_rect()
        """初始化飞船并设置其初始化位置"""
        self.x = float(self.rect.x)
        #对于每艘新飞船，都将其放在屏幕底部的中央。
        self.rect.midbottom=self.screen_rect.midbottom

    def blitme(self):
        """在指定位置绘制飞船。"""
        self.screen.blit(self.image, self.rect)

    def update(self):
        if self.moving_right:
            self.x+=self.settings.ship_speed
        if self.moving_left:
            self.x-=self.settings.ship_speed
        self.rect.x=self.x
        print(f"self.x: {self.x},self.rect.x:{self.rect.x}")