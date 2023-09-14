"""一个可用于表示汽车的类"""
class Car:
    """一次模拟汽车的简单尝试。"""
    def __init__(self,make,model,year):
        self.make = make
        self.model = model
        self.year = year
        self.odometer_reading=0

    def get_descriptive_name(self):
        """打印整洁的描述性名称"""
        long_name=f"{self.year} {self.make} {self.model}"
        return long_name.title()

    def read_odometer(self):
        """打印一条信息，指出汽车的里程."""
        print(f"This car has {self.odometer_reading} miles on it.")

    def update_odometer(self,mileage):
        """将里程表读书设置为制定的值。拒绝将里程表往回调。"""
        if mileage>=self.odometer_reading:
            self.odometer_reading=mileage
        else:
            print(f"You can't roll back an odometer!")
    def increment_odometer(self,mileage):
        """将里程表读书增加制定的量。"""
        self.odometer_reading+=mileage

