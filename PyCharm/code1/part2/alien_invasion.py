import sys
import pygame
from settings import Settings
from ship import Ship


class AlienInvasion:
    def __init__(self):
        """初始化游戏并创建游戏资源"""
        pygame.init()
        self.settings = Settings()
        self.screen = pygame.display.set_mode((self.settings.screen_width, self.settings.screen_height))
        pygame.display.set_caption("Alien Invasion")
        self.ship=Ship(self)
        self.ship.moving_left = False
        self.ship.moving_right = False


    def run_game(self):
        """开始游戏的主循环"""
        while True:
            self._check_events()
            self.ship.update()
            self._update_screen()

    def _update_screen(self):
        """更新屏幕上的图像，并切换到新屏幕."""
        self.screen.fill(self.settings.bg_color)
        self.ship.blitme()

        pygame.display.flip()

    def _check_events(self):
        """响应按键和鼠标事件。"""
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                sys.exit()
            elif event.type==pygame.KEYDOWN:
                if event.key==pygame.K_RIGHT:
                    #向右移动飞船
                    self.ship.moving_right=True
                if event.key==pygame.K_LEFT:
                    self.ship.moving_left=True

            elif event.type==pygame.KEYUP:
                self.ship.moving_right=False
                self.ship.moving_left=False




if __name__ == '__main__':
    ai = AlienInvasion()
    ai.run_game()
