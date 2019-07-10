//
//  ViewControllerSecond.h
//  Assignment1_6
//
//  Created by Subhradeep  on 3/21/19.
//  Copyright © 2019 Subhradeep . All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ViewControllerSecond : UIViewController

@property (strong, nonatomic) NSMutableArray *idData;
@property (strong, nonatomic) NSMutableArray *nameData;
@property (strong, nonatomic) NSMutableArray *positionData;
@property (strong, nonatomic) NSMutableArray *addressData;
@property (strong, nonatomic) NSMutableArray *genderData;

@property (strong, nonatomic) IBOutlet UITableView *customView;


@end
