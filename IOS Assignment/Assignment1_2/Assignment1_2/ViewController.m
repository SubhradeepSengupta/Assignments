//
//  ViewController.m
//  Assignment1_2
//
//  Created by Subhradeep  on 3/15/19.
//  Copyright © 2019 Subhradeep . All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view, typically from a nib.
}


- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}


- (IBAction)toSecondView:(UIButton *)sender {
    UIStoryboard *myStoryBoard = [UIStoryboard storyboardWithName:@"Main" bundle:nil ];
    UIViewController *VC = [myStoryBoard instantiateViewControllerWithIdentifier:@"ViewControllerSecond"];
    //[self presentViewController:VC animated:TRUE completion:nil];
    [self.navigationController pushViewController:VC animated:YES];

}
@end
