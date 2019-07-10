//
//  ViewControllerSecond.h
//  Assignment1_2
//
//  Created by Subhradeep  on 3/15/19.
//  Copyright © 2019 Subhradeep . All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ViewControllerSecond : UIViewController

- (IBAction)goToFirstView:(UIButton *)sender;

- (IBAction)firstButtonClick:(id)sender;

- (IBAction)secondButtonClick:(id)sender;

@property (weak, nonatomic) IBOutlet UIButton *radioButtonOne;

@property (weak, nonatomic) IBOutlet UIButton *radioButtonTwo;

@end
